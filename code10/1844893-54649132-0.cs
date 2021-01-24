// Setup where you just call add
System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test 1");
System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test 2");
this.listView1 = new System.Windows.Forms.ListView();
// Change Listener        
private void listView1_SelectedIndexChanged(object sender, EventArgs e)
{
    string str = listView1.Items[0].Text;
}
If you're storing an object in the `ListView` and want to access one of the properties from their you'll want to use the `Tag` property to access that, like below.
// Setup
System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("A");
listViewItem1.Tag = new ABObject()
{
    A = "A 1",
    B = "B 1",
};
System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("B");
listViewItem2.Tag = new ABObject()
{
    A = "A 2",
    B = "B 2",
};
this.listView1 = new System.Windows.Forms.ListView();
// Change Listener        
private void listView1_SelectedIndexChanged(object sender, EventArgs e)
{
    ABObject ab = (ABObject)listView1.Items[0].Tag;
    string str = ab.A;
}
