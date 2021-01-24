    private void btnLeft_Click(object sender, EventArgs e)
    {
        int visibleItemsInColumn = listBox1.ClientSize.Height / listBox1.ItemHeight; //No of items in each column. In this case - 5
        listBox1.TopIndex = listBox1.TopIndex - visibleItemsInColumn;
    }
