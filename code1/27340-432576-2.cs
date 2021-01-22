    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var b = (Button)sender;
        var grid = (Grid)b.TemplatedParent
        var lstItem = (ListBoxItem)grid.TemplatedParent;
        int index = lstBox.ItemContainerGenerator.IndexFromContainer(lstItem);
        // rest of your code here...
    }
