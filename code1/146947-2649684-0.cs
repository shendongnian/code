    bs.DataSource = Admin.GetStudents();
    dgViewStudents.AutoGenerateColumns = false;
    dgViewStudents.DataSource = bs;
    DataGridViewColumn col = new DataGridViewTextBoxColumn();
    col.DataPropertyName = "ID";
    col.HeaderText = "ID Column";
    col.Name = "foo";
    dgViewStudents.Columns.Add(col);
