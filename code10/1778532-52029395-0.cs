    private void PlusOne_Click(object sender, EventArgs e)
    {
        const int quantityColumn = 0;
        foreach (ListViewItem list in listView1.SelectedItems)
        {
            int qty = int.Parse(list.SubItems[quantityColumn].Text);
            list.SubItems[quantityColumn].Text = (qty + 1).ToString();
        }
    }
