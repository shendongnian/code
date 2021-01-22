    private DateTime m_internalDateTime;
    public string GetDateTime()
    {
        return m_internalDateTime.ToString();
    }
    
    public void SetDateTime(DateTime dateTime)
    {
        m_internalDateTime = dateTime;
    }
