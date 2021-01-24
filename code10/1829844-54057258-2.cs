    protected void cblCodeRequest_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem selectedItem = cblCodeRequest.Items[cblCodeRequest.SelectedIndex]
        
        cblCodeRequest.ClearSelection();
        int x = 0;
        for(x; x<cblCodeRequest.Items.Count; x++)
        {
             if (cblCodeRequest.Items[x].Equals(selectedItem))
             {
                 item.Selected = true;
             }
        }
    }
