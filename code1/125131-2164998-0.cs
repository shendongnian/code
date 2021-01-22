    public static class MyFilesAsStrings
    {
        public static String FirstFile {get;set;}
    
        public static LoadData() 
        {
            FirstFile = System.IO.File.ReadAllText(@"C:\Temp\MyFile.dat");
            // and so on
        }
    }
