    protected void cblCodeRequest_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem selectedItem = checkedListBox1.Items[checkedListBox1.SelectedIndex]
        
        cblCodeRequest.ClearSelection();
        foreach (ListItem item in cblCodeRequest.Items)
        {
           if (item.Equals(selectedItem))
           {
              item.Selected = true;
           }
        }
    }
