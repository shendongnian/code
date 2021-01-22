    for (int n = listBox1.Items.count - 1; n >= 0; --n)
    {
        string removelistitem = "OBJECT";
        if (listBox1.Items[n].Contains(removelistitem))
        {
            listBox1.Items.RemoveAt(n);
        }
    }
