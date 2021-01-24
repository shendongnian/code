    //MyGrid is the root panel and includes the Image which would be resized.
    private void MyGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        Debug.WriteLine("EN>>>"+e.GetCurrentPoint(MyGrid).Position);
    }
    
    private void MyGrid_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        Debug.WriteLine("ET>>>"+e.GetCurrentPoint(MyGrid).Position);
    }
