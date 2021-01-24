    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void Grid_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            Debug.WriteLine("DragStarting");
            var deferral = args.GetDeferral();
            args.Data.RequestedOperation = DataPackageOperation.Copy;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
             {
                 await Task.Delay(10000);
                 StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/StoreLogo.png"));
                 args.Data.SetStorageItems(new[] { file });
                 deferral.Complete();
             });
            
        }
        private void Grid_DragLeave(object sender, DragEventArgs e)
        {
            Debug.WriteLine("DragLeave");
        }
        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("DragEnter");
        }
        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("DragOver");
            if (!e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                e.DragUIOverride.Caption = "There're no StorageItems!";
                e.AcceptedOperation = DataPackageOperation.None;
            }
            else
            {
                e.AcceptedOperation = DataPackageOperation.Copy;
            }
        }
        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop");
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var storageFile = items[0] as StorageFile;
                    Debug.WriteLine(storageFile.DisplayName);
                }
            }
        }
        private void Grid_DropCompleted(UIElement sender, DropCompletedEventArgs args)
        {
            Debug.WriteLine("DropCompleted");
            Debug.WriteLine(args.DropResult);
        }
    }
