    using System.Collections.Generic;
    
    class OuterClass
    {
        private class BadClass
        {
            private int _data;
    
            public BadClass()
            {
                _data = 0;
    
            }
    
            public int Data
            {
              get
              {
                 return _data;
              }
              set
              {
                 _data = value;
              }
            }
        
        }
    
        void SomeMethod()
        {
            List<BadClass> a = new List<BadClass>() 
            { 
              new BadClass() { Data = 7 }, 
              new BadClass() { Data = 9 } 
            };
        }
    }
