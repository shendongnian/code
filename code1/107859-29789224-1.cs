    public partial class MainWindow : Window {
        private ObservableSetCollection<string> consolidationHeaders;
        public MainWindow() {
            InitializeComponent();
            initialize();
        }
        private void initialize() {
            consolidationHeaders = new ObservableSetCollection<string>();
            listboxConsolidationColumns.ItemsSource = consolidationHeaders;
        }
        .
        .
        .
        private void listboxAvailableColumns_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            consolidationHeaders.Append(listboxAvailableColumns.SelectedValue.ToString());
        }
        private void listboxConsolidationColumns_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            consolidationHeaders.Remove(listboxConsolidationColumns.SelectedValue.ToString());
        }
    }
