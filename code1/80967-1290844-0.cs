    static void Main(string[] args) {
        String a = "Hello ";
        String b = " World! ";
        int worldCount = 20000;
        StringBuilder worldList = new StringBuilder(b.Length * worldCount);
        worldList.append(b);
        StringBuilder result = new StringBuilder(a.Length + b.Length * worldCount);
        result.Append(a);
    
        while (worldCount > 0) {
           
           if ((worldCount & 0x1) > 0) {  // Fewer appends, more ToStrings.
              result.Append(worldList);   // would the ToString here kill performance?
           }
           worldCount >>= 1;
           if (worldCount > 0) {
              worldList.Append(worldList);
           }
        }
    
        Console.WriteLine(result.ToString());
    }
