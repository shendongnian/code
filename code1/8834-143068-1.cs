    Column<int> age = new Column<int>();
    age.Value = 35;
    age.OriginalValue = 34;
    if (ColumnService.HasChanges<Column<int>, int>(age))
    {
        ColumnService.AcceptChanges<Column<int>, int>(age);
    }
