    public partial class MainWindow : Window
    {
        ListCollectionView lcv;
        Predicate<object> filterFx;
    
        public MainWindow()
        {
            InitializeComponent();
    
            ObservableCollection<string> s = new ObservableCollection<string>();
            "The Quick Brown Fox Jumps Over The Lazy Dog"
                .Split(' ')
                .ToList()
                .ForEach((word) => s.Add(word.ToString()));
    
            this.lcv = new ListCollectionView(s);
            this.listBox.ItemsSource = this.lcv;
    
            this.filterFx = (p) => ((string)p).ToUpper().Contains(this.textBox.Text.ToUpper());
            lcv.Filter = this.filterFx;
        }
    
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lcv.Refresh();
    
            if (lcv.Count == 0)
                lcv.Filter = null;
            else
                lcv.Filter = filterFx;
        }
    }
