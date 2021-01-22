    public void Closing(object sender, EventArgs e)
    {
        lock (m_Object)
        {
            if (m_IsClosing)
                return;
                
            m_IsClosing = true;
    
            // Code, which can trigger Closing again
        
            m_IsClosing = false;
        }
    }
