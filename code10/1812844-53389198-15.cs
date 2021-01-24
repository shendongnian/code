    List<byte> varBytes = new List<byte>();
    varBytes.Add(0x12);
    varBytes.Add(0x34);
    varBytes.Add(0x56);
    varBytes.Add(0x78);
    int result1 = GetTypedString<int>(varBytes);
    long result2 = GetTypedString<long>(varBytes);
    Console.WriteLine(result1.ToString("x")); 
    Console.WriteLine(result2.ToString("x")); 
    // How fast it is (Linq and Reflection?)
    var sw = new System.Diagnostics.Stopwatch();
    int n = 10000000;
    sw.Start();
    for (int i = 0; i < n; ++i) {
      // The worst case: 
      //  1. We should expand the array
      //  2. The output is the longest one  
      long result = GetTypedString<long>(varBytes); 
      //Trick: Do not let the compiler optimize the loop
      if (result < 0)
        break;
    }
    sw.Stop();
    Console.WriteLine($"Microseconds per operation: {(sw.Elapsed.TotalSeconds/n*1000000)}");
