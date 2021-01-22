    private void PopulateDataTable()
    {
        int rowCount = 10000;
        bindingSource1.RaiseListChangedEvents = false;
        for (int i = 0; i < rowCount; i++)
        {
            DataRow r = DT.NewRow();
            for (int j = 0; j < ColumnCount; j++)
            {
                r[j] = "Column" + (j + 1);
            }
            DT.Rows.Add(r);
            if (i % 500 == 0)
            {
                bindingSource1.RaiseListChangedEvents = true;
                bindingSource1.ResetBindings(false);
                Application.DoEvents();
                bindingSource1.RaiseListChangedEvents = false;
            }
        }
        bindingSource1.RaiseListChangedEvents = true
    }
