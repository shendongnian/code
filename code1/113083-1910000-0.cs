    private void buttonMove_Click(object sender, EventArgs e)
    {
        foreach (var item in listBox1.SelectedItems.OfType<object>().ToArray())
        {
            listBox1.Items.Remove(item);
            listBox2.Items.Add(item);
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        buttonMove.Enabled = listBox1.SelectedItems.Count > 0;
    }
