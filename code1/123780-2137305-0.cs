    class CommonCode
    {
        public void HandlePaint(Control c, PaintEventArgs a)
        {
            // Do shared code
        }
        public void HandleResize(Control c)
        {
            // Do shared code
        }
    
    }
    
    class MyButton : Button
    {
        private CommonCode m_common=null;
    
        public MyButton()
        {
            m_common=new CommnCode();        
        }
        protected override OnPaint(PaintEventArgs a)
        {
            m_common.HandlePaint(this,a);
        }
    
        protected override void OnResize(EventArgs e)
        {
            m_common.HandleResize(this);
        }
    
    }
    
    class MyTextbox :Textbox
    {
    
        private CommonCode m_common=null;
    
        public MyTextbox()
        {
            m_common=new CommnCode();        
        }
        protected override OnPaint(PaintEventArgs a)
        {
            m_common.HandlePaint(this,a);
        }
    
        protected override void OnResize(EventArgs e)
        {
            m_common.HandleResize(this);
        }
    
    }
