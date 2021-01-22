    public static T[] SelectedDataRows<T>(this DataGridView dg) where T : DataRow
    {
        T[] rows = new T[dg.SelectedRows.Count];
        for (int i = 0; i < dg.SelectedRows.Count; i++)
            rows[i] = (T)((DataRowView)dg.SelectedRows[i].DataBoundItem).Row;
        return rows;
    }
