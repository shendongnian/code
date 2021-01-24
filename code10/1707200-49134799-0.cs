    //Put this code after InitializeComponent();
    ListViewA.GotFocus += ListViewFocus;
    ListViewB.GotFocus += ListViewFocus;
    
    ...
    
    private ListView Latest = null;
    private void ListViewFocus(object sender, EventArgs e)
    {
        Latest = (sender as ListView);
    }
    private void Button_Click(object sender, EventArgs e)
    {
        if (Latest == null) MessageBox.Show("No listview is focused");
        else if (Latest.Name == "ListViewA") MessageBox.Show("a");
        else MessageBox.Show("b");
    }
