    for (int i = 0; i < commandeDataGrid.Items.Count; i++)
    {
        DataRowView row = commandeDataGrid.Items[i] as DataRowView;
        if (row != null && row["Prix Total TTC"] != null)
        {
            count = count + Convert.ToInt16(row["Prix Total TTC"]);
        }
    }
