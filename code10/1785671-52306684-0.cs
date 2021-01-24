    string DestinationFolderPath = string.Empty;
    string SourceFolderPath = string.Empty;
    
    StorageFolder SourceFolder;
    StorageFolder DestinationFolder;
    
    private async void BtnChooseFolder_Click(object sender, RoutedEventArgs e)
    {
        FolderPicker FolderPickFol = new FolderPicker();
        FolderPickFol.SuggestedStartLocation = PickerLocationId.Desktop;
        FolderPickFol.FileTypeFilter.Add("*");
        Windows.Storage.StorageFolder SelectFolderToZipa = await FolderPickFol.PickSingleFolderAsync();
        StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolder", SelectFolderToZipa);
        SourceFolder = SelectFolderToZipa;
        SourceFolderPath = SelectFolderToZipa.Path;
        TxbFolderToZip.Text = SourceFolderPath;
    }
    
    private async void BtnChooseDestination_Click(object sender, RoutedEventArgs e)
    {
        FolderPicker FolderPickFol = new FolderPicker();
        FolderPickFol.SuggestedStartLocation = PickerLocationId.Desktop;
        FolderPickFol.FileTypeFilter.Add("*");
        StorageFolder SelectFolderToZipa = await FolderPickFol.PickSingleFolderAsync();
        StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedDestination", SelectFolderToZipa);
        DestinationFolder = SelectFolderToZipa;
        DestinationFolderPath = SelectFolderToZipa.Path;
        TxbZipFolder.Text = DestinationFolderPath;
    }
    
    private async void BtnZip_Click(object sender, RoutedEventArgs e)
    {
    
        if (SourceFolder != null)
        {
    
            StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", SourceFolder);
            await Task.Run(() =>
            {
                try
                {
    
                    System.IO.Compression.ZipFile.CreateFromDirectory(SourceFolderPath, $"{DestinationFolderPath}\\{SourceFolder.Name}.zip");
    
                }
                catch (Exception w)
                {
    
                }
            });
    
        }
    }
