    class FunctionButton : Button
    {
        private Color m_colorOver;
        private bool m_isPressed;
        public FunctionButton() : base()
        {
            m_isPressed = false;
        }
        protected override void OnGotFocus(EventArgs e)
        {
            OnMouseEnter(null);
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            if (!m_isPressed)
            {
                OnMouseLeave(null);
            }
            base.OnLostFocus(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (!Focused && !m_isPressed)
            {
                base.OnMouseLeave(e);
            }
        }
        public void FunctionKeyPressed()
        {
            // Handle just the first event
            if (!m_isPressed)
            {
                m_isPressed = true;
                m_colorOver = FlatAppearance.MouseOverBackColor;
                FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor;
                OnMouseEnter(null);
                PerformClick();    
            }
        }
        public void FunctionKeyReleased()
        {
            m_isPressed = false;
            FlatAppearance.MouseOverBackColor = m_colorOver;
            if (Focused)
            {
                OnMouseEnter(null);
            }
            else
            {
                base.OnMouseLeave(null);
            }
        }
    }
