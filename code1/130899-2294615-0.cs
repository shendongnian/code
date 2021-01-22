        public LED()
        {
            InitializeComponent();
            m_Image = global::AdvAdmittance.Controls.Properties.Resources.ledgray_small;
            m_ToolTip = new ToolTip();
            m_ToolTip.AutoPopDelay = 5000;
            m_ToolTip.InitialDelay = 1000;
            m_ToolTip.ReshowDelay = 500;
            m_ToolTip.ShowAlways = true;
            m_LedPictureBox.MouseHover += new EventHandler(m_LedPictureBox_MouseHover);
            m_LedPictureBox.MouseLeave += new EventHandler(m_LedPictureBox_MouseLeave);
            m_LedPictureBox.Click += new EventHandler(m_LedPictureBox_Click);
        }
        void m_LedPictureBox_MouseHover(object sender, EventArgs e)
        {
            if (m_ToolTipText != string.Empty)
            {
                Point toolTipPoint = this.Parent.PointToClient(Cursor.Position);
                toolTipPoint.Y -= 20;
                m_ToolTip.Show(m_ToolTipText, this.Parent, toolTipPoint);
            }
        }
        void m_LedPictureBox_MouseLeave(object sender, EventArgs e)
        {
            m_ToolTip.Hide(this.m_LedPictureBox);
        }
