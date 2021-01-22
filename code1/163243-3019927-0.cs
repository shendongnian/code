    public static void Main()
    {
      var list = new List<byte[]>();
      while (true)
      {
        list.Add(new byte[1024]); // Change the size here.
        Thread.Sleep(100); // Change the wait time here.
      }
    }
