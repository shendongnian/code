        protected override void OnPaint(PaintEventArgs pe)
        {
            this.DoubleBuffered = true;
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            
            angle += 0.2f;
            if (angle > 359)
            {
                angle = 0;
            }
            using (Matrix matrix = new Matrix())
            {
                matrix.Rotate(angle, MatrixOrder.Append);
                matrix.Translate(300, 200, MatrixOrder.Append);
                
                g.Transform = matrix;
                pe.Graphics.DrawEllipse(Pens.Red, new Rectangle(50, 60, 50, 50));
            }
            
            Invalidate();
        }
