    //
    // this handler's only responsibility is updating the item info label:
    //
    void someListView_ItemSelectionChanged(object sender,
                                           ListViewItemSelectionChangedEventArgs e)
    {
        if (someListView.SelectedItems.Count > 0)
        {
            // at least one item is selected; do something, e.g. update the label:
            someLabel.Text = someListView.SelectedItems[0].Text;
        }
        else
        {
            // no item is selected; do something else, e.g. clear the label:
            someLabel.Text = string.Empty;
        }
    }
