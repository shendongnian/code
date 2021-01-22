    using (ZipOutputStream s = new ZipOutputStream(File.Create("test.zip")))
    {
        s.SetLevel(0); // 0 - store only to 9 - means best compression
        string file = "test.txt";
        byte[] contents = File.ReadAllBytes(file);
        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
        s.PutNextEntry(entry);
        s.Write(contents, 0, contents.Length);
    }
