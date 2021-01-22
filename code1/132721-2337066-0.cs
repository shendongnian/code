        BindingClass ToBind = new BindingClass();
        public Window1()
        {
            InitializeComponent();
            ToBind.MyCollection = new List<string>() { "1", "2", "3" };
            this.DataContext = ToBind;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.c.SelectedItem.ToString());
        }
