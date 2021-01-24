    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            int x = 100, y = 100;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private Rectangle myShape;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                myShape = new Rectangle(x, y, 20, 20);
            }
            
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillRectangle((Brushes.Red), myShape);
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.Right)
                {
                    myShape.X += 5;
                }
    
                if (e.KeyData == Keys.Left)
                {
                    myShape.X -= 5;
                }
    
                if (e.KeyData == Keys.Up)
                {
                    myShape.Y -= 5;
                }
    
                if (e.KeyData == Keys.Down)
                {
                    myShape.Y += 5;
                }
    
                this.Refresh();
            }           
        }
    }
