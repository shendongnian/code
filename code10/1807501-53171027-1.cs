    public async Task<Foo> HeavyAsync()
    {
      while (true)
      {
        string newData = DateTime.Now.ToLongTimeString();
        Console.WriteLine(newData);
        await Task.Delay(200);
      }
      return this;
    }
