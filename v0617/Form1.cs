﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v0617
{
    public partial class Form1 : Form
    {
        int vx = rand.Next(-10, 11);
        int vy = rand.Next(-10, 11);
        int score = 100;
        string temp, face = "('ω')";
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point spos = MousePosition;
            Point fpos = PointToClient(spos);
            label3.Left = fpos.X - label3.Width / 2;
            label3.Top = fpos.Y - label3.Height / 2;
            label3.Text = $"{fpos.X},{fpos.Y}";

            label1.Left += vx;
            label1.Top += vy;

            score--;

            label2.Text = "score " + score;

            if (label1.Left < 0)
            {
                vx = Math.Abs(vx);
                temp = label1.Text;
                label1.Text = face;
                face = temp;
            }

            if (label1.Top < 0)
            {
                vy = Math.Abs(vy);
                temp = label1.Text;
                label1.Text = face;
                face = temp;
            }

            if (label1.Right > ClientSize.Width)
            {
                vx = -Math.Abs(vx);
                temp = label1.Text;
                label1.Text = face;
                face = temp;
            }

            if (label1.Bottom > ClientSize.Height)
            {
                vy = -Math.Abs(vy);
                temp = label1.Text;
                label1.Text = face;
                face = temp;
            }

            if (    (fpos.X >= label1.Left)
                &&  (fpos.X < label1.Right)
                &&  (fpos.Y >= label1.Top)
                &&  (fpos.Y < label1.Bottom)
                )
            {
                timer1.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
