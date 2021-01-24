    public sealed partial class ReaderPage : Page, View.Listener
    {
        private View view;
    }
    class MyMenuFlyoutItem : MenuFlyoutItem
    {
        private void MyMenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            // cannot access view
            dataPackage.SetText(view.vSelGetText());
            Clipboard.SetContent(dataPackage);
        }
    }
