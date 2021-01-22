    static void WriteBeginning(string filename, string insertedtext)
    {
        string tempfile = Path.GetTempFileName();
        StreamWriter writer = new StreamWriter(tempfile);
        StreamReader reader = new StreamReader(filename);
        writer.WriteLine(insertedtext);
        while (!reader.EndOfStream)
            writer.WriteLine(reader.ReadLine());
        writer.Close();
        reader.Close();
        File.Copy(tempfile, filename, true);
    }
