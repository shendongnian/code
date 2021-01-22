        class myClass
        {
            public myClass()
            {
            // this is the default constructor
            }
    
            public myClass(int myInt)
                : this(myInt, "whatever")
            {
                // do something here if needed
            }
            public myClass(string myString)
                : this(0, myString)
            {
                // do something here if needed
            }
            public myClass(int myInt, string myString)
            {
                // do something here if needed - this is the master constructor
            }
        }
