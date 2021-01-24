    BindingList<int> items = new BindingList<int>();
    private void Form1_Load(object sender, EventArgs e)
    {
        // Add some items to our binding list
        for (int i = 0; i < 5; i++)
        {
            items.Add(i);
        }
        // Bind our listbox
        listBox1.DataSource = items;
    }
        
    private void button1_Click(object sender, EventArgs e)
    {
        // Add an item to our binding list on each click
        items.Add(items.Count + 1);
    }
