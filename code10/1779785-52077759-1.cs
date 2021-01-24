    public sealed partial class ReaderPage : Page, View.Listener
    {
        // Nested class can access this field despite being declared as private
        private View view;
        class MyMenuFlyoutItem : MenuFlyoutItem
        {
            private ReaderPage page;
            MyMenuFlyoutItem(ReaderPage page)
            {
                this.page = page;
            }
            public MyMenuFlyoutItem()
            {
                this.Click += MyMenuFlyoutItem_Click;
            }
            private void MyMenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                var dataPackage = new DataPackage();
                // Nested class can access field `view` of parent class, although `view` is declared private
                // but you still need `page` reference
                dataPackage.SetText(page.view.vSelGetText());
                Clipboard.SetContent(dataPackage);
            }
        }
    }
