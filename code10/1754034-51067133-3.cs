    feedTable.MouseDown += FeedTable_MouseDown;
...
    private void FeedTable_MouseDown (object sender, MouseButtonEventArgs e)
    {
        foreach (var row in feedTableRowGroup.Rows) {
            row.GetType ().GetProperty ("Background").SetValue (row, Brushes.White);
        }
    }
