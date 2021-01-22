    class CustomTableLayoutPanel : TableLayoutPanel
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Brush brush = new LinearGradientBrush(this.ClientRectangle, TaskHeaderLeftColor, TaskHeaderRightColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            //base.OnPaintBackground(e);
        }
    }
