    namespace Test
    {
        class One
        {
            public void AccessibleToAll()
            {
            }
    
    
            internal void AccessibleWithinSameNamespace()
            {
                // I am not public
    
                // I can be accessed from other classes
                // within the same namespace of my class
            }
        }
    }
    
    namespace Test
    {
        class Two
        {
            public Two()
            {
                One one = new One();
    
                // I am able to access this method because my class
                // is in the same namespace as the class: "One"
                one.AccessibleWithinSameNamespace();
            }
        }
    }
 
