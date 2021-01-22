    public void Closing(object sender, EventArgs e)
    {
        lock (m_Object)
        {
            if (m_IsClosing)
                return;
            m_IsClosing = true;
            
            try
            {    
                // Code, which can trigger Closing again
            }
            finally
            {        
                m_IsClosing = false;
            }
        }
    }
