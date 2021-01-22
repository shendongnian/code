    public bool Pending()
    {
        if (!this.m_Active)
        {
            throw new InvalidOperationException(SR.GetString("net_stopped"));
        }
        return this.m_ServerSocket.Poll(0, SelectMode.SelectRead);
    }
