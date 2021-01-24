    class Item : ViewModelBase
    {
        public Item(string header, string textFile)
        {
            Header = header;
            this.textFile = textFile;
        }
        public string Header { get; }
        private string textFile;
        public string TextFile
        {
            get => textFile;
            set { textFile = value; OnPropertyChanged(); }
        }
        private int lineCount;
        public int LineCount
        {
            get => lineCount;
            set { lineCount = value; OnPropertyChanged(); Debug.WriteLine("Line count is now: " + value); }
        }
    }
