    using (var sr = new StreamReader(@"C:\Temp\LineTest.txt")) {
      string line;
      long pos = 0;
      while ((line = sr.ReadLine()) != null) {
        Console.Write("{0:d3} ", pos);
        Console.WriteLine(line);
        pos += line.Length;
      }
    }
