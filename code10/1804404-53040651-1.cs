    public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public ICollectionView PositionCollectionView { get; set; }
    
            public ObservableCollection<string> Roles { get; set; } = new ObservableCollection<string>();
            public ObservableCollection<string> Positions { get; set; } = new ObservableCollection<string>();
    
    
            private string _selectedRole = String.Empty;
    
            public string SelectedRole
            {
                get { return _selectedRole; }
                set
                {
                    _selectedRole = value;
                    OnPropertyChanged();
                    //This Refresh activates the Filter again, so that every time you select a role, this property will call it.
                    PositionCollectionView.Refresh();
                    
                }
            }
    
            public MainWindow()
            {
                PositionCollectionView = CollectionViewSource.GetDefaultView(Positions);
                PositionCollectionView.Filter = PositionsFilter;
    
                //use you enums here
                Roles.Add("Role1");
                Roles.Add("Role2");
                Roles.Add("Role3");
                Roles.Add("Role4");
    
                Positions.Add("Position1");
                Positions.Add("Position2");
                Positions.Add("Position3");
                Positions.Add("Position4");
    
                InitializeComponent();
            }
    
            private bool PositionsFilter(object position)
            {
                bool result = true;
                
                //place your code according to the Role selected to decide wheather "position" should be in the position list or not
    
                return result;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
