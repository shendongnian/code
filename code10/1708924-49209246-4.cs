    column0 = new string[10];
    for(int = 0; i < 10; ++i)
    {
        // Fill all elements of the first column
    }
    column1 = new string[10];
    for(int = 0; i < 10; ++i)
    {
        // Fill all elements of the secondcolumn
    }
    for (int i = 1; i < 10; i++)
    {
        string[] elements = new string[2];
        elements[0] = column0[i];
        elements[1] = column0[1];
        ListViewItem item = new ListViewItem(elements);
        listView1.Items.Add(item);
    }
