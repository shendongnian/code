      public sealed partial class Page2 : Page
        {
            public Page2()
            {
                this.InitializeComponent();
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                var items  =   e.Parameter as List<Car>;
                listCars.ItemsSource = items;
                base.OnNavigatedTo(e);
            }
        }
