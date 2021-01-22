    private volatile bool m_LayoutSuspended = false;
    public void SuspendLayout()
    {
        m_LayoutSuspended = true;
    }
    public void ResumeLayout()
    {
        m_LayoutSuspended = false;
    }
    public bool IsLayoutSuspended
    {
        get { return m_LayoutSuspended; }
    }
