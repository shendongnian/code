    using System.Windows;
    using System.Windows.Controls;
    using WpfApp2.ViewModel;
    
    namespace WpfApp2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public MainViewModel ViewModel => (MainViewModel) DataContext;
    
            private void CbUserRole_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ComboBox cb = (ComboBox)sender;
    
                if (cb != null)
                {
                    ViewModel.SelectedUserRole = (UserRole)cb.SelectedItem;
                }
            }
        }
    }
