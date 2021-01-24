    // if you do not change the list object, there is no need to raise PropertyChanged in setter
    public BindingList<Data> Data { get; set; } = new BindingList<Data>();
    // constructor
    public ViewModel(){
        // ListChanged will occor if any of the items raised a PropertyChanged event 
        List.ListChanged += (sender, arg) => OnPropertyChanged(nameof(Summary));
    }
