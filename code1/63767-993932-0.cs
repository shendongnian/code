    using System;
    
    using System.Drawing;
    
    using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Button sb;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                for (int x = 0; x < 10; x++)
                {
                    sb = new Button();
                    sb.Size = new Size(25, 25);
                    sb.Location = new Point(x * 25, 10);
                    sb.Visible = true;
                    sb.Text = x.ToString();
                    sb.Click += new EventHandler(sb_Click);
                    Controls.Add(sb);
                }
            }
    
            private void sb_Click(object sender, System.EventArgs e)
            {
                Button sb = sender as Button;
                this.Text = sb.Text;
            }
        }
