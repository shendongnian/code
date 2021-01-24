    using System.IO; //This gets you to File (Way up top with the rest of the usings)
    
    public static void Main()
    {
        string path = @"c:\[where ever you file is located].txt";
        // Check path.
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
        
           foreach(string line in lines)
           {
             if(!string.IsNullOrEmpty(line)) //Not null or empty
             {
                  //[DO STUFF -- use split if you want to go to data flow]
             }
           }
        }
    }
