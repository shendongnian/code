    class SomeElement {
       public int? NoDefault {
          get; set;
       }
    
       private int? m_hasDefault;
       public int? HasDefault {
          set { m_hasDefault = value; }
          get {
             if(m_hasDefault.HasValue)
                return m_hasDefault;
             else
                return WhateverTheDefaultShouldBe;
          }
       }
    }
