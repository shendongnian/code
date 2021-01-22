    public class ColoredButton : Control {
        protected override void OnPaint(PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 1f);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, 0, 0, Width, Height);
            graphics.DrawRectangle(pen, 0, 0, Width-1, Height-1);
        }
    }
