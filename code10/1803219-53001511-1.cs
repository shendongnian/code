     public sealed partial class MainPage : Page
        {
            public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();
    
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                GenerateSampleData();
            }
    
            private void GenerateSampleData()
            {
                for (int i = 0; i < 1000; i++)
                {
                    People.Add(new Person
                    {
                        Countries = new List<string> { "China", "India", "USA" },
                    });
                }
               
            }
    
            private void CountryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                StringBuilder sb = new StringBuilder("Added:");
                foreach (var added in e.AddedItems)
                {
                    if (added is string country)
                    {
                        sb.Append($" {country,-5}");
                    }
                }
    
                sb.Append(", Removed:");
                foreach (var removed in e.RemovedItems)
                {
                    if (removed is string country)
                    {
                        sb.Append($" {country,-5}");
                    }
                }
                Debug.WriteLine(sb);
            }
    
            private void CountryList_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
               People[999].Country = "India";
            }
        }
