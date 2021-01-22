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
        int index = -1; //First char index in the file is 0
        index = content.IndexOf("abc");
        // Outputs the next two caracters
        // [!] We need to validate if we are at the end of the text
        if ((index >= 0) && (index < content.Length - 4))
        {
            Console.WriteLine(content.Substring(index + 3, 2));
        }
