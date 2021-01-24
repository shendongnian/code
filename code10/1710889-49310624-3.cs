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
            this.DrawMode = DrawMode.OwnerDrawVariable;
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
            this.Enter += (s, ev) => { this.InvalidateParent(BorderActive); };
            this.Leave += (s, ev) => { this.InvalidateParent(BorderInactive); };
            this.Move += (s, ev) => { this.InvalidateParent(Color.Transparent); };
            base.OnHandleCreated(e);
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
            Rectangle rect = this.Bounds;
            rect.Inflate(1, 1);
            using (Pen pen = new Pen(ActionBorderColor, 1))
                e.Graphics.DrawRectangle(pen, rect);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            using (SolidBrush bkBrush = new SolidBrush(this.DropDownBackColor))
                e.Graphics.FillRectangle(bkBrush, e.Bounds);
            using (SolidBrush foreBbrush = new SolidBrush(this.DropDownForeColor))
                e.Graphics.DrawString(this.Items[e.Index].ToString(),
                                      this.Font, foreBbrush, new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
    }
