    var sw = new Stopwatch();
    sw.Start();
    double sum = 0;
    var fs = new FileStream("demo.txt", FileMode.Open, FileAccess.Read);
    using (var bs = new BufferedStream(fs))
    using (var r = new StreamReader(bs))
    {
        r.ReadLine();
        while (!r.EndOfStream)
        {
            var l = r.ReadLine();
            var split = l.Split();
            var x = float.Parse(split[0]);
            var y = float.Parse(split[1]);
            var z=float.Parse(split[2]);
            sum += x + y + z;
        }
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds / 1000M);
    Console.WriteLine(sum);
