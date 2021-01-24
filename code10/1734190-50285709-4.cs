    class Program  
    {  
        public ClassOne Class1 { get; set; }  
        public Program()  
        {  
            Class1 = new ClassOne()
            {
                SupportedFiles = new string[] { "Test", "Test" }
            };
           //class1.SupportedFiles[0] = "First";
           //class1.SupportedFiles[1] = "Second"; 
        }  
    }
