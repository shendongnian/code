    private bool m_IsClosing;
    
    public void Closing(object sender, EventArgs e)
    {
        lock(m_Object)
        {
            // Check for state.
            if(m_IsClosing)
                return;
    
            m_IsClosing = true;
    
            try
            {
                // The rest of your code.
            }
            finally
            {
                m_IsClosing = false;
            }
        }
    }
