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
        			foreach(ListViewItem item in masterlist.Where(lvi => lvi.Text.ToLower().Contains(textBox1.Text.ToLower().Trim())))
			{
				listView1.Items.Add(item);
			}
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // Re-display the items when the filter changes
        DisplayItems();
    }
