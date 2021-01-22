    static int Main() 
    {
         byte[] data = File.ReadAllBytes("anyfile");
         SomeMethod(data);
    }
    static void SomeMethod(IEnumerable<byte> data)
    {
        byte b = data.ElementAt(0); 
        // Notice that the ElementAt extension method is sufficiently intelligent
        // to use the indexer in this case instead of creating an enumerator
    }
