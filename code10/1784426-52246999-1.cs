    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        checkedListBox1.BeginInvoke(new Action(() =>
        {
            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)
            {
                checkedListBox1.Items.Clear();
            }
        }));
    }
