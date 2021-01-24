    public sealed partial class MainPage : Page
    {
        public ObservableCollection<FolderInfo> storageFolders { get; set; } = new ObservableCollection<FolderInfo>();
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add(".txt");
            var folder = await folderPicker.PickSingleFolderAsync();
            var Folders = await GetFoldersAsync(folder);
            foreach (var f in Folders)
            {
                storageFolders.Add(f);
            }
        }
        private async Task<ObservableCollection<FolderInfo>> GetFoldersAsync(StorageFolder storageFolder)
        {
            var folders = await storageFolder.GetFoldersAsync();
            ObservableCollection<FolderInfo> folderInfos = new ObservableCollection<FolderInfo>();
            foreach (var f in folders)
            {
                folderInfos.Add(new FolderInfo() {FolderName=f.DisplayName,subFolders=await GetFoldersAsync(f) });
            }
            return folderInfos;
        }
    }
