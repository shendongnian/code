    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace DetailsSample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (textBox2.Height > 0)
                {
                    this.Size = new Size(this.Size.Width, button1.Location.Y +
                                                          button1.Height +
                                                          button1.Margin.Bottom +
                                                          27);
                    button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    textBox1.Anchor |= AnchorStyles.Bottom;
                    textBox2.Anchor ^= AnchorStyles.Top;
                }
                else
                {
                    button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    textBox1.Anchor ^= AnchorStyles.Bottom;
                    textBox2.Anchor |= AnchorStyles.Top;
                    this.Size = new Size(this.Size.Width, textBox2.Location.Y +
                                                          160);
                }
            }
        }
    }
