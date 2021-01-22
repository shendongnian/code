    private List<Action> commitActions = new List<Action>();
    public bool SomeProperty
    {
        get
        {
            return m_SomeProperty;
        }
        set
        {
            if (m_SomeProperty != value)
            {
                m_SomeProperty = value;
                lock (commitActions)
                {
                    commitActions.Add(
                        () => Properties.Settings.Default.SomeProperty = value);
                }
                NotifyPropertyChanged("SomeProperty");
            }
        }
    }
