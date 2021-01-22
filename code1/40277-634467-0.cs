    protected void lvPopup_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        // Set the text of the first list view item to the selected item 
        // of the second list view.
        lstView1.Items[lstView1.SelectedIndex].Text = 
            lstView2.Items[lstView2.SelectedIndex].Text
    }
