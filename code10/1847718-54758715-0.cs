    public static byte[] SomethingFunky(byte[] bytes)
    {
       var list = bytes.ToList();
       if (bytes.Length % 2 != 0)
          list.Insert(0,0);
    
       return Enumerable.Range(0, list.Count)
                        .Where(x => x % 2 == 0)
                        .Select(x => (byte)(list[x] * 10 + list[x + 1]))
                        .ToArray();
    }
