            private readonly StringFormat CenterSringFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
    
            [Category("Colors"), Description("The background color of the components Active tab.")]
            public Color ActiveColor { get; set; } = Color.FromArgb(0, 122, 204);
    
            [Category("Colors"), Description("The background color of the components Inactive tab(s).")]
            public Color BackTabColor { get; set; } = Color.Black;
    
            [Category("Colors"), Description("The color used for the components tab borders.")]
            public Color BorderColor { get; set; } = Color.Black;
    
            [Category("Colors"), Description("The color used for the components header area.")]
            public Color HeaderColor { get; set; } = Color.Black;
    
            [Category("Colors"), Description("The color used for the components horizontal line.")]
            public Color HorizLineColor { get; set; } = Color.FromArgb(0, 122, 204);
    
            [Category("Colors"), Description("The ACTIVE tab foreground color this component, which is used to display text.")]
            public Color SelectedTextColor { get; set; } = Color.White;
    
            [Category("Colors"), Description("The INACTIVE tab foreground color this component, which is used to display text.")]
            public Color TextColor { get; set; } = Color.White;
    
            [Category("Colors"), Description("Indicates whether the component will be double buffered.")]
            public bool BufferDoubled { get { return DoubleBuffered; } set { DoubleBuffered = value; } }  //Really don't think I need to expose this
    
            public VSTabControl()
            {
                InitializeComponent();
    
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.Clear(HeaderColor);
    
                if (TabCount > 0) SelectedTab.BackColor = BackTabColor;
    
                for (int i = 0; i < TabCount; i++)
                {
                    Rectangle gtr = GetTabRect(i); Rectangle Header = new Rectangle(new Point(gtr.X + 2, gtr.Y), new Size(gtr.Width, gtr.Height));
                    Rectangle HeaderSize = new Rectangle(Header.Location, new Size(Header.Width, Header.Height));
    
                    if (i == SelectedIndex)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(HeaderColor), HeaderSize);
                        e.Graphics.FillRectangle(new SolidBrush(ActiveColor), new Rectangle(Header.X - 5, Header.Y - 3, Header.Width, Header.Height + 5));
                    }
    
                    e.Graphics.DrawString(TabPages[i].Text, Font, new SolidBrush((i == SelectedIndex) ? SelectedTextColor : TextColor), HeaderSize, CenterSringFormat);
                }
    
                e.Graphics.DrawLine(new Pen(HorizLineColor, 5), new Point(0, 19), new Point(Width, 19));
    
                e.Graphics.FillRectangle(new SolidBrush(BackTabColor), new Rectangle(0, 20, Width, Height - 20));
                e.Graphics.DrawRectangle(new Pen(BorderColor, 2), new Rectangle(0, 0, Width, Height));
            }
