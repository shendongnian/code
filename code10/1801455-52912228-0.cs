    for (int s = 0; s < Contents.Count; s++)
    {
       var content = Contents[s];
    
       allTasks.Add(
          Task.Run(async () =>
                      {
                         await throttle.WaitAsync();
                         try
                         {
                            rootResponse[s] = await POSTAsync(content, siteurl, src, target);
                         }
                         finally
                         {
                            throttle.Release();
                         }
                      }));
    }
    await Task.WhenAll(allTasks);
