    private void DG_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            foreach (DataGridColumn c in DG.Columns)
                c.Width = 0;
            DG.UpdateLayout();
            foreach (DataGridColumn c in DG.Columns)
                c.Width = DataGridLength.Auto;
        }
