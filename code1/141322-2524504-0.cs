    public bool IsDirty { get { return m_IsDirty; } }
    public string Name {
        set
        {
            m_Name = value;
            m_IsDirty = true;
        }
    }   
