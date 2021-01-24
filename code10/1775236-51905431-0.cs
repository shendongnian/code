    class GradientGroupBox : GroupBox
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public GradientGroupBox() => this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Color gradFillTo = Color.FromArgb(200, SystemColors.Window);
            Color gradFillFrom = Color.FromArgb(128, this.Parent.BackColor);
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, gradFillFrom, gradFillTo, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= WS_EX_TRANSPARENT;
                return parameters;
            }
        }
    }
