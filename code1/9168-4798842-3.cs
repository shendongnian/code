    public class ToolButton : Button
    {
        private bool ShowBorder { get; set; }
        public ToolButton()
            : base()
        {
            // Prevent the button from drawing its own border
            FlatAppearance.BorderSize = 0;
            // Set up a blue border and back colors for the button
            FlatAppearance.BorderColor = Color.FromArgb(51, 153, 255);
            FlatAppearance.CheckedBackColor = Color.FromArgb(153, 204, 255);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 204, 255);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 224, 255);
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // Set the size for the button to be the same as a ToolStripButton
            Size = new System.Drawing.Size(23, 22);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Show the border when you hover over the button
            ShowBorder = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Hide the border when you leave the button
            ShowBorder = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // The DesignMode check here causes the border to always draw in the Designer
            // This makes it easier to place your button
            if (DesignMode || ShowBorder)
            {
                Pen pen = new Pen(FlatAppearance.BorderColor, 1);
                Rectangle rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }
        // Prevent Text from being set on the button (since it will be an icon)
        [Browsable(false)]
        public override string Text { get { return ""; } set { base.Text = ""; } }
        [Browsable(false)]
        public override ContentAlignment TextAlign { get { return base.TextAlign; } set { base.TextAlign = value; } }
    }
