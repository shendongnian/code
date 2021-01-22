    public class my_progress_bar : ProgressBar {
            public Brush brush;
            public my_progress_bar() {
                this.SetStyle(ControlStyles.UserPaint, true);
                brush = Brushes.ForestGreen;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                //base.OnPaint(e);
                Rectangle rectangle = e.ClipRectangle;
                rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum)) - 4;
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
                rectangle.Height = Height - 4;
                e.Graphics.FillRectangle(brush, 2, 2, rectangle.Width, rectangle.Height);
            }
        }
