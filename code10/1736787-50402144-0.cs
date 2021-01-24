    DataGridViewComboBoxColumn dtgcombo = new DataGridViewComboBoxColumn();
    dtgcombo.DataSource = Enum.GetNames(typeof(Uom));
    dataGridView1.Columns.Add(dtgcombo);
    dataGridView1.Rows.Add("0", Uom.meters.ToString());
    dataGridView1.Rows.Add("0", "");
    dataGridView1.Rows.Add("0", Uom.not_known.ToString());
