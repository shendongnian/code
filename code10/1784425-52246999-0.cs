    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        this.BeginInvoke(new Action(() =>
        {
            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)
            {
                checkedListBox1.Items.Clear();
            }
        }));
    }
