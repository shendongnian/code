    {
        string newItem = "This is count: " + count;
        if(listBox1.Items.IndexOf(newItem) < 0)
        {
            listBox1.Items.Add(newItem);
        }
    }
