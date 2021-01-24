     public YourFullNamesListPage()
        {
            InitializeComponent();
            _nameList =  new ObservableCollection<NameObject>(_nameList OrderByDescending(x => x.Name));
            FullNamesList.ItemsSource= _nameList;
        }
