    static void WriteABC(string filename)
    {
        string tempfile = Path.GetTempFileName();
        StreamWriter writer = new StreamWriter(tempfile);
        StreamReader reader = new StreamReader(filename);
        writer.WriteLine("A,B,C");
        while (!reader.EndOfStream)
            writer.WriteLine(reader.ReadLine());
        writer.Close();
        reader.Close();
        File.Copy(tempfile, filename, true);
    }
