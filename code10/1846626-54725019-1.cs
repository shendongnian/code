    using (var fs = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
    using (var fs2 = new FileStream("test.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
    {
        byte[] info = new UTF8Encoding(true).GetBytes("DEF_");
        byte[] info2 = new UTF8Encoding(true).GetBytes("abc_");
        for (int i = 0; i < 3; i++)
        {
            fs.Seek(0, SeekOrigin.End);
            fs.Write(info, 0, info.Length);
            fs.Flush();
            fs2.Seek(0, SeekOrigin.End);
            fs2.Write(info2, 0, info2.Length);
            fs2.Flush();
        }
    }
