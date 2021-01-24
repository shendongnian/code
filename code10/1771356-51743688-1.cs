    public ObservableCollection<int> Collection { get; } = new ObservableCollection<int>();
    public void AddRecord()
    {
        Collection.Add(1);
        NotifyOfPropertyChange(nameof(CanAddRecord));
    }
    public bool CanAddRecord => Collection.Count == 0;
