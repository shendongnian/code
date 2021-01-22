    protected void removeButton_Click(object sender, EventArgs e)
    {
        for (int i = listBox.Items.Count - 1; i >= 0; i--)
            listBox.Items.RemoveAt(i);
    }
