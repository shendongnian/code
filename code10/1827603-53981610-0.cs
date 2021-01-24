      var tasks = new List<Task>();
      foreach (var fileListObj in indicators.file_list)
      {
        tasks.Add(Task.Factory.StartNew( () => { //Doing Stuff }));
      }
      await Task.WhenAll(tasks.ToArray());
    }
