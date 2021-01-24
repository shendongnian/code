    var r = new Random();
    var bytes = new byte[100000000];
    var bytes2 = new byte[100000000];
    r.NextBytes(bytes);
    
    var sw = Stopwatch.StartNew();
    Array.Copy(bytes,bytes2,bytes.Length);
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
