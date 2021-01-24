    private bool m_spinProp;
    public MainVM()
    {
        m_spinProp = true;
    }
    public bool SpinProperty
    {
        get { return m_spinProp; }
        set { SetProperty(ref m_spinProp, value); }
    }
