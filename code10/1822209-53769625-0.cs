    string MyNewFile;
    using (StreamWriter sWriter = new StreamWriter(MyNewFile, false, encoding, 1))
    {
        using (StreamReader sReplaceReader = new StreamReader(myFile))
        {
            string line, textLine = "";
    
            while ((line = sReplaceReader.ReadLine()) != null)
            {
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{4,}", options);     
                string textLine = regex.Replace(line, "|");
                
                sWriter.WriteLine(textLine);
            }
        } 
    }
