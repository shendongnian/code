    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set data context
            DataContext = new ViewModel();
        }
    
        /// <summary>
        /// Called when selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get event sender
            var listBox = sender as ListBox;
            // Create temp list for selected items
            var tempList = new List<string>();
    
            foreach (string item in listBox.SelectedItems)
            {
                tempList.Add(item);
            }
    
            (DataContext as ViewModel).OnSelectionChanged(tempList);
        }
    }
