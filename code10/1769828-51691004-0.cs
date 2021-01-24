    private async Task AddTextToFile(String textToSave)
    {
        var appFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        var file = await appFolder.CreateFileAsync("exposure.txt", 
            Windows.Storage.CreationCollisionOption.OpenIfExists);
        await Windows.Storage.FileIO.AppendTextAsync(file, textToSave + Environment.NewLine);
        // Look in Output Window of Visual Studio for path to file
        System.Diagnostics.Debug.WriteLine(String.Format("File is located at {0}", file.Path.ToString()));
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await AddTextToFile(String.Format("MinimumExposure {0}", DateTime.Now.Millisecond.ToString()));
    }
