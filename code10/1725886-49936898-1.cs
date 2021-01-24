    public partial class MainWindow : Window
    {
        public ObservableCollection<Foo> Foos { get; set; } 
            = new ObservableCollection<Foo>() { new Foo() { FooName = "A1" }, new Foo { FooName = "A2" }, new Foo() { FooName = "A3" } };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var foo in Foos)
                foo.IsSelected = false;
            foreach (var foo in Foos)
                if (foo.FooName == (sender as Button)?.Tag as string)
                    foo.IsSelected = true;
        }
    }
