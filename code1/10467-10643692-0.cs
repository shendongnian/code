    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    
    
    namespace Whatever.Test
    {
        public static class Extensions
        {
            public static int Compare(this MyObject t1, MyObject t2)
            {
                if(t1.SomeValueField < t2.SomeValueField )
                    return -1;
                else if (t1.SomeValueField > t2.SomeValueField )
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public static MyObject Add(this MyObject t1, MyObject t2)
            {
                var newObject = new MyObject();
                //do something  
                return newObject;
  
            }
    
            public static MyObject Subtract(this MyObject t1, MyObject t2)
            {
                var newObject= new MyObject();
                //do something
                return newObject;    
            }
        }
        
    }
