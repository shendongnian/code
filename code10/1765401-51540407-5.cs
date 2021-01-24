    public class ViewModel
    {
        public event EventHandler<string> OpenUrl;
        // List filled with the MyDataObject
        public ObservableCollection<MyDataObject> Collection { get; set; }
        private void FillCollection()
        {
            // Create all MyDataObjects here
            // Each object will be created like this
            Collection.Add(new MyDataObject("insert url here", OpenUrlFromObject));
        }
        private void OpenUrlFromObject(string url)
        {
            OpenUrl?.Invoke(this, url); // Subscribe to this event in your Page and open
        }
    }
