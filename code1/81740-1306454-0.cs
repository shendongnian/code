    class FunctionButton : Button
    {
        private Color m_colorOver;
        public FunctionButton() : base() {}
        protected override void OnGotFocus(EventArgs e)
        {
            OnMouseEnter(null);
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            OnMouseLeave(null);
            base.OnLostFocus(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (!Focused)
            {
                base.OnMouseLeave(e);
            }
        }
        public void FunctionKeyPressed()
        {
            m_colorOver = FlatAppearance.MouseOverBackColor;
            FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor;
            OnMouseEnter(null);
            PerformClick();
        }
        public void FunctionKeyReleased()
        {
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
