    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Add("Some Text " + listBox1.Items.Count.ToString());
        //The max number of items that the listbox can display at a time
        int NumberOfItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
        if (listBox1.TopIndex == listBox1.Items.Count - NumberOfItems - 1)
        {
            //The item at the top when you can just see the bottom item
            listBox1.TopIndex = listBox1.Items.Count - NumberOfItems + 1;
        }
    }
