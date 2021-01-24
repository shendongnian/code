    var itemsL1 = new ListBox.ObjectCollection(listBox1, listBox1.Items);
    listBox1.Items.Clear();
    listBox1.Items.AddRange(listBox2.Items);
    listBox2.Items.Clear();
    listBox2.Items.AddRange(itemsL1);
