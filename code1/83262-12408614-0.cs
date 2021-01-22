    private string m_myProperty;
    public string MyProperty
    {
        get { return m_myProperty; }
        set
        {
            m_myProperty = value;
            OnPropertyChanged();
        }
    }
    private void OnPropertyChanged([CallerMemberName] string propertyName = "none passed")
    {
        // ... do stuff here ...
    }
