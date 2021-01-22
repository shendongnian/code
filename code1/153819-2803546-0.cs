    using System;
    
    namespace ClassLibrary3
    {
        public class Class1
        {
            private string _Name = "Lasse";
    
            public Class1()
            {
            }
    
            public Class1(int i)
                : this()
            {
            }
    
            public Class1(bool b)
            {
                _Name = "Test";
            }
        }
    }
