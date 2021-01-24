    private void Form1_Load(object sender, EventArgs e)
    {
        var products = LoadProducts();
        var categories = LoadCategories();
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
        {
            Name = "NameColumn",
            DataPropertyName = "Name",
            HeaderText = "Name"
        });
        dataGridView1.Columns.Add(new DataGridViewComboBoxColumn()
        {
            Name = "CategoryIdColumn",
            DataPropertyName = "CategoryId",
            HeaderText = "Category",
            DataSource = categories,
            ValueMember = "Id",
            DisplayMember = "Name",
            DisplayStyle= DataGridViewComboBoxDisplayStyle.Nothing
        });
        dataGridView1.DataSource = products;
        dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        dataGridView1.CellPainting += DataGridView1_CellPainting;
    }
