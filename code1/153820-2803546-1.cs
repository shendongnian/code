    using System;
    
    namespace ClassLibrary3
    {
        public class Class1
        {
            private string _Name;
    
            public Class1()
            {
                _Name = "Lasse"
            }
    
            public Class1(int i)
                : this()
            {
                // not here, as this() takes care of it
            }
    
            public Class1(bool b)
            {
                _Name = "Lasse"
                _Name = "Test";
            }
        }
    }
