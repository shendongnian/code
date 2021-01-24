    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            var item = await TestGetNewFile("test.txt"); 
        }
    }
    async Task<IStorageItem> TestGetNewFile(string fileName)
    {
         return await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);         
    }
