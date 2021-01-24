    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var shopItem = (e.OriginalSource as FrameworkElement).DataContext as ShopItem;
        shopItem.IsBookAvailable = !shopItem.IsBookAvailable;
    }
