    protected void lbxSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem itm = lbxSource.SelectedItem;
        ListItem newItem = new ListItem(itm.Text, itm.Value);
        lbTrg.Items.Add(newItem);
        lbxSource.ClearSelection(); // This line is the answer to your question
    }
