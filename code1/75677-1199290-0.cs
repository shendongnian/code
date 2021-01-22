    dataGridView1.DataSource = new OrderCollection().Load();
    
    var comboBox1 = dataGridView1.Columns["colProduct"];
    comboBox1.DisplayMember = Product.Columns.Name; // or just "Name"
    comboBox1.ValueMember = Product.Columns.Id;
    comboBox1.DataSource = new ProductCollection().OrderBy(Product.Columns.Name).Load();
    comboBox1.DataPropertyName = Order.ProductId;
