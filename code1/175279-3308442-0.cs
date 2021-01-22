    FileInfo x = new FileInfo(@"path\to\original");
    string xpath = x.FullName;
    FileInfo y = new FileInfo(@"path\to\temporary\new\file");
    
    using (var reader = x.OpenText())
    using (var writer = y.AppendText())
    {
        // write 1st line
        writer.WriteLine(reader.ReadLine());
        reader.ReadLine(); // skip 2nd line
        // write all remaining lines
        while (!reader.EndOfStream)
        {
            writer.WriteLine(reader.ReadLine());
        }
    }
    x.Delete();
    y.MoveTo(xpath);
