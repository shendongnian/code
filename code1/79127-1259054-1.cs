    using (StreamReader reader = new StreamReader(@"D:\infile.txt"))
    using (StreamWriter writer = new StreamWriter(@"D:\outfile.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line.Trim());
        }
    }
    
    // Some File.Move(..) usage to rename the files
