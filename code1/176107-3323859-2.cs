    [RootWorkItem(Inject = true)]
    private RootWorkItem m_RootWorkItem;
    public RootWorkItem RootWorkItem {
    
    	get {
    		if (m_RootWorkItem == null) {
    			m_RootWorkItem = new RootWorkItem();
    		}
    		return m_RootWorkItem;
    	}
    }
