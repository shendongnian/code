    string filename = @"C:\Temp\junk.txt";
    string tempfile = @"C:\Temp\junk_temp.txt";
    using (StreamReader reader = new StreamReader(filename))
    {                
        using (StreamWriter writer = new StreamWriter(tempfile))
        {
            string line = reader.ReadLine();
                    
            while (!reader.EndOfStream)
            {
                writer.WriteLine(line);
                line = reader.ReadLine();
            } // by reading ahead, will not write last line to file
        }
    }
    File.Delete(filename);
    File.Move(tempfile, filename);
