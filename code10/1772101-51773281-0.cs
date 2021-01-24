    int GetSortColumnIndex()
    {
        foreach (DataControlField field in GridView1.Columns)
        {
            if (field.SortExpression == GridView1.SortExpression)
            {
                return GridView1.Columns.IndexOf(field);
            }
        }
    }
