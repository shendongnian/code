    private void ResizeTree()
    {
        var MaxWidth = Convert.ToDouble(MyGrid.ColumnDefinitions[0].ActualWidth);
        foreach (TreeViewItem item in MyTree.Items)
        {
            var Header = item.Header as TextBlock;
            var Body = item.Items[0] as TextBlock;
            Header.Width = MaxWidth - 30;
            Body.Width = MaxWidth - 60;
        }
    }
