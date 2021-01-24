    // if you do not change the list object, there is no need to raise PropertyChanged in setter
    public BindingList<Data> Data { get; set; } = new BindingList<Data>();
    // constructor
    public ViewModel(){
        // Update property Summary if our list changes.
        List.ListChanged += (sender, arg) => OnPropertyChanged(nameof(Summary));
    }
