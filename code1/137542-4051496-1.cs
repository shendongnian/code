    int mCount = ListBox1.Items.Count;
    for (int i = 0; i <= mCount - 1; i++)
    {
        if (ListBox1.Items[i] == ListBox1.SelectedItem)
        {
            ListBox2.Items.Add(ListBox1.SelectedItem);
            ListBox1.Items.Remove(ListBox1.SelectedItem);
            mCount=mCount - 1;
            i=i - 1;
        }
    }
