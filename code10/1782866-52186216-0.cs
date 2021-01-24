    public class OpenFileClass
    {
        public async Task<IStorageFile> OpenFileAsync()
        {
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            openPicker.FileTypeFilter.Add(".txt");
            openPicker.FileTypeFilter.Add(".csv");
            return await openPicker.PickSingleFileAsync();
        }
    }
