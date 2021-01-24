    private void dgv_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    {
        var g = (DataGridView)sender;
        var property = typeof(DataGridViewColumn).GetProperty("DisplayIndexHasChanged",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (g.Columns.Cast<DataGridViewColumn>().Any(x => (bool)property.GetValue(x)))
            return;
        else
            MessageBox.Show("Changed");
    }
