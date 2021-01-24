    private ObservableCollection<SetupSFE> _sourceForSFEList = new ObservableCollection<SetupSFE>();
    public ObservableCollection<SetupSFE> SourceForSFEList
    {
        get { return _sourceForSFEList; }
        set
        {
            _sourceForSFEList.Clear();
            if (value != null)
            {
                foreach (var item in value)
                {
                    _sourceForSFEList.Add(item);
                }
                
            }
        }
    }
