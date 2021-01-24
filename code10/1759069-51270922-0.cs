      public void FillTable()
     {
        TableResult.Clear();
        TableResult.Columns.Clear();
        TableResult.Columns.Add(new DataColumn() { ColumnName = "Color" });
        TableResult.Columns.Add(new DataColumn() { ColumnName = "Is it Cool?" });
        TableResult.Rows.Add(new object[]{ "Red", "Yes" });
        TableResult.Rows.Add(new object[]{ "Pink", "Absolutely not" });
       NotifyPropertyChanged(nameof(TableResult));
     }
