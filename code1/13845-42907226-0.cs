    [Test]
    public void TestShortArray()
    {
      var n = 100000000;
      var input = new short[n];
      var r = new Random();
      for (var i = 0; i < n; i++) input[i] = (short)r.Next();
      var bf = new BinaryFormatter();
      var sw = new Stopwatch();
      using (var ms = new MemoryStream())
      {
        sw.Start();
        bf.Serialize(ms, input);
        sw.Stop();
        Console.WriteLine("BinaryFormatter serialize: " +
          sw.ElapsedMilliseconds + " ms, " + ms.ToArray().Length + " bytes");
        sw.Reset();
        ms.Seek(0, SeekOrigin.Begin);
        sw.Start();
        var output = (short[])bf.Deserialize(ms);
        sw.Stop();
        Console.WriteLine("BinaryFormatter deserialize: " +
          sw.ElapsedMilliseconds + " ms, " + ms.ToArray().Length + " bytes");
        Assert.AreEqual(input, output);
      }
      sw.Reset();
      using (var ms = new MemoryStream())
      {
        var bw = new BinaryWriter(ms, Encoding.UTF8, true);
        sw.Start();
        bw.Write(input.Length);
        for (var i = 0; i < input.Length; i++) bw.Write(input[i]);
        sw.Stop();
        Console.WriteLine("BinaryWriter serialize: " +
          sw.ElapsedMilliseconds + " ms, " + ms.ToArray().Length + " bytes");
        sw.Reset();
        ms.Seek(0, SeekOrigin.Begin);
        var br = new BinaryReader(ms, Encoding.UTF8, true);
        sw.Start();
        var length = br.ReadInt32();
        var output = new short[length];
        for (var i = 0; i < length; i++) output[i] = br.ReadInt16();
        sw.Stop();
        Console.WriteLine("BinaryReader deserialize: " +
          sw.ElapsedMilliseconds + " ms, " + ms.ToArray().Length + " bytes");
        Assert.AreEqual(input, output);
      }
    }
