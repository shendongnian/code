    DataTable dt = new DataTable();
    dt.Columns.Add("No", typeof(int));
    dt.Columns.Add("Name");
    dataGridView1.AllowUserToAddRows = true;
    dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
    dataGridView1.DataSource = dt;
