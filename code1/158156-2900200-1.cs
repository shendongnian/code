        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = this;
    
                SizeChanged += new SizeChangedEventHandler(MainWindow_SizeChanged);
    
                list = new ObservableCollection<string>();
                list.Add("item1");
                list.Add("item2");
                list.Add("item3");
            }
    
            public ObservableCollection<string> list { get; set; }
    
            void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                listbox1.Margin = new Thickness(this.ActualWidth * 0.84,
                                                this.ActualHeight * 0.3, 0, 0);
            }
        }
