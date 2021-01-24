    private bool m_IsAuthenticated;
    
    public bool IsAuthenticated {
      get {
        return m_IsAuthenticated;
      }
    }
    
    public void Set_IsAuthenticated_ForTestONLY(bool value) {
      m_IsAuthenticated = value;
    }
