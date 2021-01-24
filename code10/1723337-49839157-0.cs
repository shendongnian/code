    // NOTE: NOT RECOMMENDED; SEE BELOW
    // Populate the tag as before
    newListViewItem.Tag = new { XPATH = FindXPath(node) };
    // Recover Tag property using a variable of type dynamic
    dynamic myObj = myListView.Items[0].Tag;
    string xpath = myObj.XPATH;
