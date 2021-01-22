    // Open a stream and read it back.
    using (FileStream fs = File.OpenRead(path))
    {
        byte[] b = new byte[1024];
        UTF8Encoding temp = new UTF8Encoding(true);
        while (fs.Read(b,0,b.Length) > 0)
        {
            Console.WriteLine(temp.GetString(b));
        }
    }
