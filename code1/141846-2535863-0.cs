        class A
            {
                private string foo_; // It could be any other class/struct too (Vector3, Matrix...) 
        
                public A(string shared)
                {
                    this.foo_ = shared;
                }
        
                public void Bar(ref string myString)
                {
                   myString = "changed";
                }
            }
    
    static void Main()
            {
                string str = "test";
                A a = new A(str);
    
                Console.WriteLine(str); // "test" 
                a.Bar(ref str);
                Console.WriteLine(str);
    
            }
