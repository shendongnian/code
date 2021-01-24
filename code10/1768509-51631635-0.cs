    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
    
            int i = 0;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
              
    
            }
    
            
            void btn1_Click(object sender, EventArgs e)
            {
                textBox1.Controls.Clear();
                textBox1.Text = textBox1.Text.Remove(1, textBox1.Lines[0].Length + 0);
                textBox1.Text = textBox1.Text.Remove(0, textBox1.Lines[0].Length + 0);
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                Button btn1 = new Button();
                btn1.Name = "btn"+i++;
                btn1.Click += new EventHandler(button1_Click_1);
                btn1.Size = new Size(18,18 );
                btn1.Text = "X";
                btn1.Location = new Point(0, i);
                i += 18;
                btn1.ForeColor = Color.Red;
                this.textBox1.Controls.Add(btn1);
    
    
                string sent = ("\t" + "Testline1");
    
                textBox1.AppendText(sent);
                textBox1.AppendText(Environment.NewLine);
    
               
            }
        }
    }
