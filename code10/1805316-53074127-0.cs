    static void Main(string[] args)
            {
    
    
                string path = "your_file_path";
    
                string text = System.IO.File.ReadAllText(path);
    
                string[] parsedText= text.Split(';');
    
                foreach (var item in parsedText)
                {
                    //do some
                }
    
            }
