    if (e.OriginalSource is Shape s)
    {
        cellColumn = (int)s.GetValue(Grid.ColumnProperty);
        cellRow = (int)s.GetValue(Grid.RowProperty);
        rectangle[cellRow, cellColumn].Fill = Brushes.Green;
    }
