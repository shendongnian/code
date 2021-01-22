    protected void Button2_Click(object sender, EventArgs e)
    {
        for(int i = ListBox1.Items.Count -1; i>=0; i--)
        {
            if (ListBox1.Items[i].Selected)
            {
                ListBox1.Items.Remove(ListBox1.Items[i]);
            }
        }
    }
