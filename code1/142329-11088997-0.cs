    namespace StackoverflowExample
    {
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
        }
        void NewWindowAsDialog(object sender, RoutedEventArgs e)
        {
          Window myOwnedDialog = new Window();
          myOwnedDialog.Owner = this;
          myOwnedDialog.ShowDialog();
        }
        void NormalNewWindow(object sender, RoutedEventArgs e)
        {
          Window MyOwnedWindow = new Window();
          MyOwnedWindow.Owner = this;
          MyOwnedWindow.Show();
        }
      }
    }
