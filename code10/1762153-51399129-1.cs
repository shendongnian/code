    int secs = 5;
    using (var fs = new FileStream("Hello.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
    {
        fs.WriteAppend("Beginning of the elaboration\r\n", Encoding.UTF8);
        long pos1 = fs.WriteAppend("Step 1\r\n", Encoding.UTF8);
        long pos2 = fs.WriteAppend($"Working 0\r\n", Encoding.UTF8);
        for (int i = 1; i < 10; i++)
        {
            Thread.Sleep(secs * 1000);
            fs.RewriteTruncate(pos2, $"Working {i}\r\n", Encoding.UTF8);
        }
        Thread.Sleep(secs * 1000);
        fs.RewriteTruncate(pos1, $"Finished working\r\n", Encoding.UTF8);
    }
