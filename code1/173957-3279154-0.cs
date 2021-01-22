    adp.Dispose();
    comFna.DataSource = null; //ADD THIS LINE HERE OR comFna.Items.Clear();
    comFna.DataSource = dsNa.Tables[0];
    comFna.DisplayMember = dsNa.Tables[0].Columns[0].ColumnName;
    comFna.ValueMember = dsNa.Tables[0].Columns[1].ColumnName;
