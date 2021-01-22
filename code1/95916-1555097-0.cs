    System.Threading.Thread.Sleep(0); // Let the other threads get started on the list.
    lock(obj) 
    {
      foreach (string str in list)
      {
        Console.WriteLine(str);
      }
    }
