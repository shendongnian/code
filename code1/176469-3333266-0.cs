        public class MyType
        {
            public string this[int index]
            {
                get 
                { 
                    //getter implementation
                }
                set 
                { 
                    //setter implementation
                }
            }
        }
    
        public class Usage
        {
            public MyType usageType = new MyType();
    
            public Usage()
            {
                usageType[0] = "xx";
            }
        }
