    public Form1()
    {
        InitializeComponent();
        dataGridView2.ColumnCount = 4;
        dataGridView2.Columns[0].Name = "Item";
        dataGridView2.Columns[1].Name = "Quantity";
        dataGridView2.Columns[2].Name = "Unit Price";
        dataGridView2.Columns[3].Name = "Unit Total";
    }
    int total = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        int item;
        int.TryParse(textBox1.Text, out item);
        int qty;
        int.TryParse(textBox2.Text, out qty);
        int price = itemprice(item);
        int unit_total = price * qty;
               
        if (dataGridView1.SelectedRows.Count == 1)
        {
            dataGridView2.Rows.Add(item, qty, price, unit_total);
            total +=unit_total;
            textBox5.Text = total.ToString();
        }
    }
