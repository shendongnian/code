	private string m_TName;
    public string TName
    {
        get {return m_TName + counter;}
        set {
        	if (m_TName != value){
        		m_TName = value
        	}
        }
    }
