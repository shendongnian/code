    private DataMember<bool> m_Monday;
    public bool? Monday
    {
        get
        {
            if (m_Monday.HasValue)
                return m_Monday.Get();
            else
                return null;
        }
        set
        {
            if (value.HasValue)
                m_Monday.Set(value.Value);
            else
                m_Monday.SetNull();
        }
    }
