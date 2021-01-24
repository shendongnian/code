    var sw = new Stopwatch();
    sw.Start();
    double sum = 0;
    var fs = new FileStream("demo.bin", FileMode.Open, FileAccess.Read);
    using (var bs = new BufferedStream(fs))
    using (var r = new BinaryReader(bs))
    {
        for (int i = 0; i < 75000000; i++)
        {
            var x = r.ReadSingle();
            var y = r.ReadSingle();
            var z=r.ReadSingle();
            sum += x + y + z;
        }
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds / 1000M);
    Console.WriteLine(sum);
