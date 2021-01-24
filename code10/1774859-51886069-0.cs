    List<ListViewItem> masterlist;
    public Form1()
    {
        InitializeComponent();
        masterlist = new List<ListViewItem>();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        // Populate the masterlist
        masterlist.Clear();
        foreach(string s in getList())
        {
            masterlist.Items.Add(new ListViewItem(s));
        }
        
        // Display the items in the listview
        DisplayItems();
    }
    private void DisplayItems()
    {
        listView1.Items.Clear();
        // This filters and adds your filtered items to listView1
        listView1.Items.AddRange(
                                  masterlist.Cast<ListViewItem>()
                                            .Where(lvi => lvi.Text.ToLower().Contains(textBox1.Text.ToLower().Trim()))
        );
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // Re-display the items when the filter changes
        DisplayItems();
    }
