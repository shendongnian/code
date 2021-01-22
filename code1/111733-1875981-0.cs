    using (StreamReader stream = new StreamReader(File.Open(@"YourFilePath", FileMode.Open)))
    {
        string fileText = stream.ReadToEnd();
    
        // Do your replacements
        fileText = fileText.Replace(@"<\HRM>", string.Empty);
        fileText = fileText.Replace(@"HRM\", ";");
    
        using (StreamWriter writer = new StreamWriter(File.Open("@YourFilePath", FileMode.Create)))
        {
            // You do a create because the new file will have less characters than the old one
            writer.Write(fileText);
        }
    }
