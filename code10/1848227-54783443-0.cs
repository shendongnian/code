    // Define data table
    var dt = new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("Price", typeof(int));
    
    // Fill data
    dt.Rows.Add("Product 1", 100);
    dt.Rows.Add("Product 2", 200);
    
    // Set data source of data grid view
    this.dataGridView1.DataSource = dt;
    
    // Automatically update text box, by SUM of price
    textBox1.Text = $"{dt.Compute("SUM(Price)", ""):F2}";
    dt.DefaultView.ListChanged += (obj, args) =>
        textBox1.Text = $"{dt.Compute("SUM(Price)", ""):F2}";
