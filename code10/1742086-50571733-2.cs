      public partial class MainWindow : Window
      {
          public MainWindow()
          {
              InitializeComponent();
    
              lvConnections.ItemsSource = new ObservableCollection<ConnectionItem>()
              {
                  new ConnectionItem("Starts Connected") { Status = ConnectionStatus.Connected, },
                  new ConnectionItem("Starts Ready") { Status = ConnectionStatus.Ready, },
                  new ConnectionItem("Starts Default"),
              };
          }
    
          private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
          {
              var item = (sender as ListViewItem)?.DataContext as ConnectionItem;
              switch (item.Status)
              {
                  case ConnectionStatus.Connected:
                      item.Status = ConnectionStatus.Ready;
                      break;
                  case ConnectionStatus.Ready:
                      item.Status = ConnectionStatus.Disconnected;
                      break;
                  default:
                      item.Status = ConnectionStatus.Connected;
                      break;
              }
          }
      }
