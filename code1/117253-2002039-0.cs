    namespace Sample
    {
         public Class TestObject
         {
              private Object m_MyAwesomeObject;
    
              public TestObject()
              {
              }
              public Object MyAwesomeObject
              {
                  get
                  {
                      if (m_MyAwesomeObject == null)
                          m_MyAwesomeObject = new Object();
    
                      return m_MyAwesomeObject;
                  }
              }
         }
    }
