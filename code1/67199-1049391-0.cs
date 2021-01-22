      // Example ViewModel
    public class MyClass : INotifyPropertyChanged
    {
        private string text;
        public string Text
        {
            get { return text; }
            set 
            { 
                text = value;
                UpdateProperty("Text");
                UpdateProperty("HasContent");
            }
        }
        public bool HasContent
        {
            get { return !string.IsNullOrEmpty(text); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void UpdateProperty(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
