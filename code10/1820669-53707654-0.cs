    private void TextBox_GotFocus(objetc sender, RoutedEventArgs e)
    {
         var txtControl = sender as TextBox;
         txtControl.Dispatcher.BeginInvoke(new Action(() =>
         {
           txtControl.SelectAll();
         }));
    }
