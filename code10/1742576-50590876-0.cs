    public  Task<bool> ExecuteAsync()
    {
        return  ItReturnsATask();
    }
    public async Task DoSomethingAsync()
    {
        var tasks = new List<Task>();
          foreach (var item in someList)
          {
            //ExecuteAsync can be replace by ItReturnsATask if there's no extra processing
                tasks.Add(ExecuteAsync());
          }
         await Task.WhenAll(tasks);
    }
