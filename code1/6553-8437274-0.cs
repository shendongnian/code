    var sw = new Stopwatch();
    var ab = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
    
    // create
    var fs = new FileStream(@"d:\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 262144, FileOptions.None);
    sw.Restart();
    fs.Seek(0, SeekOrigin.Begin);
    for (var i = 0; i < 40000000; i++) fs.Write(ASCIIEncoding.ASCII.GetBytes(ab), 0, ab.Length);
    sw.Stop();
    Console.WriteLine("{0} ms", sw.Elapsed.TotalMilliseconds);
    fs.Dispose();
    
    // insert
    fs = new FileStream(@"d:\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 262144, FileOptions.None);
    sw.Restart();
    byte[] b = new byte[262144];
    long target = 10, offset = fs.Length - b.Length;
    while (offset > 0)
    {
        fs.Position = offset; fs.Read(b, 0, b.Length);
        fs.Position = offset + target; fs.Write(b, 0, b.Length);
        offset -= b.Length;
        if (offset < 0)
        {
            offset = b.Length - target;
            b = new byte[offset];
        }
    }
    fs.Position = target; fs.Write(ASCIIEncoding.ASCII.GetBytes(ab), 0, ab.Length);
    sw.Stop();
    Console.WriteLine("{0} ms", sw.Elapsed.TotalMilliseconds);
