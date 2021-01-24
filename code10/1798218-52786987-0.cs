    static void Main(string[] args)
    {
      var list = new List<string>();
      void mutateList()
      {
        for (var i = 0; i < 1000000; i++)
        {
          list.Add("foo");
        }
      }
      for (var i = 0; i < Environment.ProcessorCount; i++)
      {
        new Thread(mutateList).Start();
      }
      Thread.Sleep(-1);
    }
