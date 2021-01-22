    interface MyInterface : INotifyPropertyChanged
    {
        string Text { get; set; }
    }
    class MyViewModel : MyInterface
    {
        private string text;
        public string Text 
        {
            get { return text; }
            set 
            { 
                if (text != value)
                {
                   text = value;
                   // TODO: Raise the NotifyPropertyChanged event here
                }
            }
        }
    }
