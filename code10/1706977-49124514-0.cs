    private int grandTotal = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        string item_code = textBox1.Text;
        int item;
        int.TryParse(item_code, out item);
        string quantity  = textBox2.Text;
        int qty;
        int.TryParse(quantity, out qty);
        int price = itemprice(item);
        int unit_total = price * qty;
        int total = 0;
        if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedRows.Count < 2)
        {
                dataGridView2.ColumnCount = 4;
                dataGridView2.Columns[0].Name = "Item";
                dataGridView2.Columns[1].Name = "Quantity";
                dataGridView2.Columns[2].Name = "Unit Price";
                dataGridView2.Columns[3].Name = "Unit Total";
                dataGridView2.Rows.Add(item, qty, price, unit_total);
                grandTotal =grandTotal + unit_total;
                textBox5.Text = Convert.ToString(grandTotal );
        }
    }
