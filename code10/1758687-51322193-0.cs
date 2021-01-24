    private void MyImage_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        var point= e.GetCurrentPoint(sender as Image).Position;
    }
    
    private void MyImage_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Image).Position;
    }
