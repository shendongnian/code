    class Master : INotifyPropertyChanged
    {
        public int Id { get; set; } // + property changed implementation 
        public string Name { get; set; } // + property changed implementation
        public double Sum {get {return Details.Sum(x=>x.Value);}}
    
        public DeeplyObservableCollection<Detail> Details { get; }
        // hooked up in the constructor
        void OnDOCChanged(object sender, CollectionChangedEventArgs e) 
        { OnPropertyChanged("Sum"); }
    }
