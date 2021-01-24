    private string header = "Item";
    public string Header
        {
            get => header;
            private set
            {
                header = value;
                RaisePropertyChanged(() => Header);
            }
        }
