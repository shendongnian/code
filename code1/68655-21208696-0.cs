    //In Fill DataGridViewEvent :
            DataGridViewCheckBoxColumn ChCol = new DataGridViewCheckBoxColumn();
            ChCol.Name = "CheckedRow";
            ChCol.HeaderText = "انتخاب";
            ChCol.Width = 50;
            ChCol.TrueValue = "1";
            ChCol.FalseValue = "0";
            dg.Columns.Insert(0, ChCol);
    // In Button Event put these codes:
                try
                {
                    MessageBox.Show(row.Cells[2].Value.ToString() + " --> " +
                    row.Cells["CheckedRow"].Value.ToString());
                }
                catch
                {
                    // Nothing Act
                }
    enter code here
