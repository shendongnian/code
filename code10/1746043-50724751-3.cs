    private void btnRight_Click(object sender, EventArgs e)
    {
        int visibleItemsInColumn = listBox1.ClientSize.Height / listBox1.ItemHeight;
        listBox1.TopIndex = listBox1.TopIndex + visibleItemsInColumn;
    }
