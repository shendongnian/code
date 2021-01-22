        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectionChanged+=new SelectionChangedEventHandler(comboBox1_SelectionChanged);
        }
        protected void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            label1.Content = ((ComboBoxItem)comboBox1.Items[comboBox1.SelectedIndex]).Content;
        }
