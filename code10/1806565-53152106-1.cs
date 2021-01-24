    DataView dataView = commandeDataGrid.ItemsSource as DataView;
    if (dataView != null)
    {
        foreach (DataRowView row in dataView)
        {
            if (row["Prix Total TTC"] != null)
            {
                count = count + Convert.ToInt16(row["Prix Total TTC"]);
            }
        }
    }
