    void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var dataContext = ((FrameworkElement)e.OriginalSource).DataContext;
        if (dataContext is Track)
        {
            MessageBox.Show("Item's Double Click handled!");
        }
    }
