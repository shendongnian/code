    class MyMenuFlyoutItem : MenuFlyoutItem
    {
        public MyMenuFlyoutItem()
        {
            this.Click += MyMenuFlyoutItem_Click;
        }
    
        private void MyMenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(SelGetText());
            Clipboard.SetContent(dataPackage);
        }
    
        private string SelGetText()
        {
            return this.Text;
        }
    }
 
