    private async void writeTextToTem(string info)
    {
        var file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("info.text", CreationCollisionOption.OpenIfExists);
    
        if (file != null)
        {
            await Windows.Storage.FileIO.WriteTextAsync(file, info);
        }
    }
