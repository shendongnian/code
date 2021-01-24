      var tasks = new List<Task>();
                    for (int i = 0; i < loopCount; i++)
                    {
                        tasks.Add(TestSave());
    
                    }
      Task.WhenAll(tasks);
    
      or using Paralle.Foreach
