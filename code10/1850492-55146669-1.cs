    using (DataTable dt = (dgvBindingSource.DataSource as DataTable))
    {
        DataRow row = dt.NewRow();
        row["Column0"] = SomeValue1;
        row["Column1"] = SomeValue2;
        row["Column2"] = SomeValue3;
        dt.Rows.Add(row);
    }
