    private void cbOrderID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox combo = (sender as ComboBox);
        DataRowView selectedItem = (combo.SelectedItem as DataRowView);
        this.BindGrid(selectedItem);
    }
    private void BindGrid(DataRowView comboItem)
    {
        int OrderID = (int)comboItem.Row["OrderID"];
        DataView view = new DataView(OrdersTable());
        view.RowFilter = string.Format("OrderID = {0}", OrderID);
        this.dataGridView1.DataSource = view;
    }
