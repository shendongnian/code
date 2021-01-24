    public async Task GetImages()
    {
        for (int i = 0; i < someCounter; i++)
        {
            var img = await myRequest.GetImage(url);
            // for your small wait.
            await Task.Delay(100);
        }
    }
