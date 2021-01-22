    public string Name
    {
        get { return m_Name; }
        set 
        {
            OnPropertyChanged(Name);
            m_Name = value; 
        }
    }
