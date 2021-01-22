    String tempFile = Path.GetTempFileName(), read = "";
    using(TextReader pending = new StreamReader("c:\\pending.txt"))
    using(TextWriter temp = new StreamWriter(tempFile))
    {
        read = pending.ReadLine();
        while ((read = pending.ReadLine()) != null)
        {
            temp.WriteLine(read);
        }
    }
    File.Delete(@"c:\pending.txt");
    File.Move(tempFile, @"c:\pending.txt");
