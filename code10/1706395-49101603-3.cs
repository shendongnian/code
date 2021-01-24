     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var listItemObj = myListView.Items.Add(new MyListItem {Icon = "Default Icon", Text = "Default Text"});
            }
        }
