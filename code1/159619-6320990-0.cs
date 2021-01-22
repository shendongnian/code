      bool horizontal= false;
            protected override void OnPaint(PaintEventArgs e)
            {
                if (horizontal)
                {
                    Height = 1;
                    e.Graphics.DrawLine(Pens.Black, 0, 0, Width, 1);
                }
                else
                {
                    Width = 1;
                    e.Graphics.DrawLine(Pens.Black, 0, 0, 1, Height);
                }
            }
