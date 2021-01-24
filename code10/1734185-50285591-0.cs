    using SomeClass;
    class Program  
        {  
            //Not required to create property of ClassOne
            //public ClassOne class1 { get; set; }  
            public Program()  
            {  
               //In this way, you can create instance of class.
               ClassOne class1 = new ClassOne();
               //Now with the help of instance of class, you can access all public properties of that class
                class1.SupportedFiles= new string[] { "Test", "Test" };
               //class1.SupportedFiles[0] = "First";
               //class1.SupportedFiles[1] = "Second"; 
            }  
        }
