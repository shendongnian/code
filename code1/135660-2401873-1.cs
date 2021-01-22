    static void WriteABC(string filename)
    {
        string tempfile = Path.GetTempFileName();
        using (var writer = new StreamWriter(tempFile))
        using (var reader = new StreamReader(filename))
        {
            writer.WriteLine("A,B,C");
            while (!reader.EndOfStream)
                writer.WriteLine(reader.ReadLine());
        }
        File.Copy(tempfile, filename, true);
    }
