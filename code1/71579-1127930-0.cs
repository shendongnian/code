    public void DisplayMetadataExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        var nbSelectedItem = (MyItem)e.Parameter;
        // do stuff with selected item
    }
    public void DisplayMetadataCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
        e.Handled = true;
    }
