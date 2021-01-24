    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tree.SelectedItemChanged += Tree_SelectedItemChanged;
        }
        private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MessageBox.Show(((TreeViewItem)e.NewValue).Header.ToString());
        }
    }
