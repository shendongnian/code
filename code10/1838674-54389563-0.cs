    private void BtnRemoveSource_Click(object sender, RoutedEventArgs e)
    {
        AdditionalSourceCounter--;
        var callingButton = (Button)sender;
        int rowNumber = Grid.GetRow(callingButton);
        int callingButtonIndex = GridSource.Children.IndexOf(callingButton);
        foreach ( var child in GridSource.Children.ToArray() )
        {
            var childRow = (int)child.GetValue(Grid.RowProperty);
            if (childRow == rowNumber)
            {
                //this child should be removed
                GridSource.Children.Remove(child); 
            }
            else if (childRow > rowNumber)
            {
                //move items on next rows one row up
                child.SetValue(Grid.RowProperty, childRow - 1);
            }
        }
        GridSource.RowDefinitions.RemoveAt(rowNumber);
        Grid.SetRow(btnAddSource, GridSource.RowDefinitions.Count - 1);
    }
