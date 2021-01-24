    Public ICollectionView MainListView;
    Public ICollectionView PhaseInContractView;
    Public ObservableCollection<YourDataClass> MainList;
    public YourViewModel()
    {
        MainList = new ObservableCollection<YourDataClass>();
        // Load datas form db and fill MainList
        MainListView = new CollectionViewSource() { Source = MainList }.View;
        MainListView.Filter = (x) =>
        {
            // your MainListView filtering logic.
        };
        PhaseInContractView = new CollectionViewSource() { Source = MainList }.View;
        PhaseInContractView.Filter = (x) =>
        {
            // your PhaseInContractView filtering logic
        };
    private Affaire selectedAffaire;
    public Affaire SelectedAffaire
    {
        get { return selectedAffaire; }
        set
        {
            selectedAffaire = value;
            this.NotifyPropertyChanged("SelectedAffaire");
            if (value != null)
            {
               PhaseInContractView.Refresh();
            }
            MainListView.Refresh();
        }
    }
    // And other properties.
    ...
