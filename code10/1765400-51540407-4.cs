    public class MyDataObject
    {
        private Action<string> _openUrl;
        private string _url;
        public MyDataObject(string url, Action<string> openUrl)
        {
            _url = url;
            _openUrl = openUrl;
            ClickCommand = new Command(AccessOtherData);
        }
        public ICommand ClickCommand { get; }
        // Other data properties and such
        private void AccessOtherData()
        {
            // Call method to open _url
            _openUrl(_url);
        }
    }
