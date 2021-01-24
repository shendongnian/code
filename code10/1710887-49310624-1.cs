    public class CustomCombo : ComboBox
    {
        private Color ActionBorderColor = Color.Empty;
        public CustomCombo()
        {
            InitializeComponent();
        }
        public Color BorderActive { get; set; }
        public Color BorderInactive { get; set; }
        public Color DropDownBackColor { get; set; }
        public Color DropDownForeColor { get; set; }
        private void InitializeComponent()
        {
            this.BorderActive = Color.OrangeRed;
            this.BorderInactive = Color.Transparent;
            this.DropDownBackColor = Color.FromKnownColor(KnownColor.Window);
            this.DropDownForeColor = this.ForeColor;
            this.HandleCreated += new EventHandler(this.OnControlHandle);
        }
        protected void OnControlHandle(object sender, EventArgs args)
        {
            Form parent = this.FindForm();
            parent.Paint += new PaintEventHandler(this.ParentPaint);
            this.DrawItem += new DrawItemEventHandler(this.OnControlDrawItem);
            this.Enter += (s, e) => { this.InvalidateParent(BorderActive); };
            this.Leave += (s, e) => { this.InvalidateParent(BorderInactive); };
            this.Move += (s, e) => { this.InvalidateParent(Color.Transparent); };
        }
        private void InvalidateParent(Color bordercolor)
        {
            ActionBorderColor = bordercolor;
            Rectangle rect = this.Bounds;
            rect.Inflate(2, 2);
            this.FindForm().Invalidate(rect);
        }
        protected void ParentPaint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(ActionBorderColor, 2);
            Rectangle rect = this.Bounds;
            e.Graphics.DrawRectangle(pen, rect);
        }
        protected void OnControlDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds);
            e.Graphics.DrawString(this.Items[e.Index].ToString(),
                                  this.Font,
                                  new SolidBrush(this.DropDownForeColor),
                                  new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
    }
