        class Contact : INotifyPropertyChanged
        {
            public bool _IsON;
            public bool IsON { get => _IsON; set { _IsON = value;  MainTxtClr = _IsON ? Color.Green : Color.Red; ; OnPropertyChanged(nameof(MainTxtClr)); } }
        
            public string Name { get; set; }
            public string Status { get; set; }
            public string ImageUrl { get; set; }
            public Color MainTxtClr { get; set; }
            public string ButtonText { get; set; }
            public Contact()
            {
                MainTxtClr = PS.MainTextColor();
                IsON = true;
                ButtonText = "Follow Text";
            }
    public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName]string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
