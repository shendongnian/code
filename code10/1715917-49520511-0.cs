    class ClickableRectangle
    {
        private Rectangle _box;
        public event EventHandler Click;
        public ClickableRectangle(Rectangle coordinates)
        {
            _box = coordinates;
        }
        public void BindToControl(Control control)
        {
            control.MouseUp += Control_MouseUp;
            control.Paint += Control_Paint;
        }
        private void Control_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, _box);
        }
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X < _box.Left) return;
            if (e.X > _box.Right) return;
            if (e.Y < _box.Top) return;
            if (e.Y > _box.Bottom) return;
            if (Click == null) return;
            Click(sender, e);
        }
    }
