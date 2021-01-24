    public async void GetImages()
    {
       var tasks = new List<Task>();
       for (int i = 0; i < someCounter; i++)
       {
          tasks.Add(myRequest.GetImage(url));
       }
       await Task.WhenAll(tasks).ConfigureAwait(false);
    }
