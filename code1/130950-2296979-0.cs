        private ButtonState state = ButtonState.Normal;
        public ButtonCell(): base()
        {
            this.Size = new Size(100, 40);
            this.Location = new Point(50, 50);
            this.Font = SystemFonts.IconTitleFont;
            this.Text = "Click here";     
        }
        private void DrawFocus()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Rectangle r = Rectangle.Inflate(this.ClientRectangle, -4, -4);
            ControlPaint.DrawFocusRectangle(g, r);
            g.Dispose();
        }
        private void DrawFocus(Graphics g)
        {
            Rectangle r = Rectangle.Inflate(this.ClientRectangle, -4, -4);
            ControlPaint.DrawFocusRectangle(g, r);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (state == ButtonState.Pushed)
                ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle, Border3DStyle.Sunken);
            else
                ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle, Border3DStyle.Raised);
            TextRenderer.DrawText(e.Graphics, Text, this.Font, e.ClipRectangle, this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            DrawFocus();
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            DrawFocus();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = ButtonState.Pushed;
            Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            state = ButtonState.Normal;
            Invalidate();
            base.OnMouseUp(e);
        }
