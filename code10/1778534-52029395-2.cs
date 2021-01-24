    private void PlusOne_Click(object sender, EventArgs e)
    {
        const int quantityColumn = 0;
        int increment = int.Parse(PlusOne.Text);
        foreach (ListViewItem list in listView1.SelectedItems)
        {
            int qty = int.Parse(list.SubItems[quantityColumn].Text);
            list.SubItems[quantityColumn].Text = (qty + increment).ToString();
        }
    }
