    public sealed partial class MainPage : Page, INotifyPropertyChanged
            {
                public ObservableCollection<Show> Shows { get; } = new ObservableCollection<Show>();
        
                private Show _selectedShow;
                public Show SelectedShow
                {
                    get => _selectedShow;
                    set
                    {
                        if (_selectedShow != value)
                        {
                            _selectedShow = value;
                            OnPropertyChanged();
                        }
                    }
                }
        
                public MainPage()
                {
                    this.InitializeComponent();
                    Shows.Add(new Show("Show 1"));
                    Shows.Add(new Show("Show 2"));
                    Shows.Add(new Show("Show 3"));
                    SelectedShow = Shows[0];
                }
        
                private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    Debug.WriteLine("now selected: " + SelectedShow.Name);
                }
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
                   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
