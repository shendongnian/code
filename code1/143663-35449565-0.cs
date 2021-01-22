        public CSStackPanelItem()
        {
            InitializeComponent();
            MouseEnter += new EventHandler(CSStackPanelItem_MouseEnter);
            foreach (Control child in Controls)
            {
                child.MouseEnter += (s, e) => CSStackPanelItem_MouseEnter(s, e);
                child.MouseLeave += (s, e) => OnMouseLeave(e);
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                return; //suppress mouse leave event handling
            if (m_bIsHover)
            {
                m_bIsHover = false;
                Invalidate(); //actually my mouse Enter/Leave event
            }
            base.OnMouseLeave(e);
        }
        void CSStackPanelItem_MouseEnter(object sender, EventArgs e)
        {
            m_bIsHover = true;
            Invalidate(); //actually my mouse Enter/Leave event
        }
