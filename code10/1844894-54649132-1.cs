// Setup
listView.Items.Add(new ABTest()
{
    A = "A 1",
    B = "B 1"
});
listView.Items.Add(new ABTest()
{
    A = "A 2",
    B = "B 2"
});
// Change Listener        
private void listView1_SelectedIndexChanged(object sender, EventArgs e)
{
    ABTest ab = (ABTest)listView.SelectedItem;
    string str = ab.A;
}
