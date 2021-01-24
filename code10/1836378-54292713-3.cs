    private List<String> comboSource;
    private void Form1_Load(object sender, EventArgs e)
    {
        comboSource = new List<string> { "A", "B" };
        var dt = new DataTable();
        dt.Columns.Add("C1");
        dt.Columns.Add("C2", typeof(int));
        dt.Rows.Add("A", 100);
        dt.Rows.Add("B", 200);
        var c1 = new DataGridViewComboBoxColumn();
        c1.Name = "C1";
        c1.DataPropertyName = "C1";
        c1.DataSource = comboSource;
        var c2 = new DataGridViewTextBoxColumn();
        c2.Name = "C2";
        c2.DataPropertyName = "C2";
        dataGridView1.Columns.AddRange(c1, c2);
        this.dataGridView1.DataSource = dt;
        dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
    }
