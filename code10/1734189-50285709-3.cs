    class Program  
    {  
        public ClassOne Class1 { get; set; }  
        public Program()  
        {  
            Class1 = new ClassOne();
            Class1.SupportedFiles= new string[] { "Test", "Test" };
        }  
    }
