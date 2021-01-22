    private MyObject m_Y = new MyObject();
    
    public MyObject Y
    {
         get { return m_Y; }
         set
         {
             m_Y = value;
             X = value;      // Here ...
         }
    }
