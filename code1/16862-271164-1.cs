    protected void removeButton_Click( object sender, EventArgs e )
    {
        if (listBox.SelectedIndex >= 0)
        {
            listBox.Items.RemoveAt( listBox.SelectedIndex );
        }
    }
