    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace DoubleBufferTest
    {
        public partial class Form1 : Form
        {
            private BufferedGraphicsContext context;
            private BufferedGraphics grafx;
            public Form1()
            {
                InitializeComponent();
                this.Resize += new EventHandler(this.OnResize);
                DoubleBuffered = true;
                // Retrieves the BufferedGraphicsContext for the 
                // current application domain.
                context = BufferedGraphicsManager.Current;
                UpdateBuffer();
            }
            
            private void timer1_Tick(object sender, EventArgs e)
            {
                this.Refresh();
            }
            private void OnResize(object sender, EventArgs e)
            {
                UpdateBuffer();
                this.Refresh();
            }
            private void UpdateBuffer()
            {
                // Sets the maximum size for the primary graphics buffer
                // of the buffered graphics context for the application
                // domain.  Any allocation requests for a buffer larger 
                // than this will create a temporary buffered graphics 
                // context to host the graphics buffer.
                context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                // Allocates a graphics buffer the size of this form
                // using the pixel format of the Graphics created by 
                // the Form.CreateGraphics() method, which returns a 
                // Graphics object that matches the pixel format of the form.
                grafx = context.Allocate(this.CreateGraphics(),
                     new Rectangle(0, 0, this.Width, this.Height));
                // Draw the first frame to the buffer.
                DrawToBuffer(grafx.Graphics);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                grafx.Render(e.Graphics);
            }
            private void DrawToBuffer(Graphics g)
            {
                //Graphics g = grafx.Graphics;
                Pen pen = new Pen(Color.Blue, 1.0f);
                //Random rnd = new Random();
                for (int i = 0; i < Height; i++)
                    g.DrawLine(pen, 0, i, Width, i);
            }
        }
    }
