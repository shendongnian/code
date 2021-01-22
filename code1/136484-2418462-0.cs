     // Find the full path of our document
            System.IO.FileInfo ExecutableFileInfo = new System.IO.FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location);            
            string path = System.IO.Path.Combine(ExecutableFileInfo.DirectoryName, "MyTextFile.txt");
    
        // Read the content of the file
        string content = String.Empty;
        using (StreamReader reader = new StreamReader(path))
        {
            content = reader.ReadToEnd();
        }
        // Find the pattern "abc"
        int index = content.Length - 1;
                             
        System.Collections.ArrayList coincidences = new System.Collections.ArrayList();
                  
        while(content.Substring(0, index).Contains("abc"))
        {
            index = content.Substring(0, index).LastIndexOf("abc");
            if ((index >= 0) && (index < content.Length - 4))
            {
                coincidences.Add("Found coincidence in position " + index.ToString() + ": " + content.Substring(index + 3, 2));                    
            }
        }
        coincidences.Reverse();
        foreach (string message in coincidences)
        {
            Console.WriteLine(message);
        }
        Console.ReadLine();
