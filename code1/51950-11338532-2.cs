    protected void btnAdd_Click(object sender, EventArgs e)
    {
        while(listBox1.SelectedIndex!=-1)
        {
               listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
