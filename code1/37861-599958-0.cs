    public static DataRowView[] ForBinding(this DataRow row)
    {
        foreach (DataRowView rowView in row.Table.DefaultView)
        {
            if (ReferenceEquals(rowView.Row, row))
            {
                return new DataRowView[] { rowView };
            }
        }
        throw new ArgumentException("Row not found in the default view", "row");
    }
