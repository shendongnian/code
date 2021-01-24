    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp23
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            Timer t1;
    
            Stopwatch s1;
            Stopwatch s2;
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                s1 = new Stopwatch();
                s2 = new Stopwatch();
    
                t1 = new Timer();
                t1.Interval = 1;
                t1.Tick += T1_Tick;
                t1.Start();
            }
    
            private void T1_Tick(object sender, EventArgs e)
            {
                textBox1.Text = s1.ElapsedMilliseconds.ToString();
                textBox2.Text = s2.ElapsedMilliseconds.ToString();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                s1.Start();
                s2.Start();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                s1.Stop();
                s2.Stop();
            }
        }
    }
