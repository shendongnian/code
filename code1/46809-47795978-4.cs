    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((ProjectViewModel)DataContext)
                .ProjectClick.Execute(((ListViewItem)sender).Content);
        }
    }
