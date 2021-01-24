    static public string FolderAccessToken { get; set; }
    private async void Pick_Button_Click(object sender, RoutedEventArgs e)
    {
        var picker = new FolderPicker();
        picker.FileTypeFilter.Add(".xml");        
        var folder = await picker.PickSingleFolderAsync();
        if (folder == null)
        {
            FolderAccessToken = "";
            return;
        }
    
        FolderAccessToken = StorageApplicationPermissions.FutureAccessList.Add(folder);
    }
    
    private async void Get_Button_Click(object sender, RoutedEventArgs e)
    {
        var folder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(FolderAccessToken);
    }
