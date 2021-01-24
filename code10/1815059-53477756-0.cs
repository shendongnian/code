    int sum = 0;
    for (int i = 0; i < TruckDataGrid2.Rows.Count; ++i)
    {
        sum += Convert.ToInt32(TruckDataGrid2.Rows[i].Cells[2].Value);
    }
    label1.text = sum.ToString();
