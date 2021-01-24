    protected void cblCodeRequest_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        int count = 0;
        int i = 0;
        ListItem selectedItem = new ListItem();
        foreach (ListItem item in cblCodeRequest.Items)
        {
            if (item.Selected)
            {
               count++;
               selectedItem = item;
            }
        }
        cblCodeRequest.ClearSelection();
        foreach (ListItem item in cblCodeRequest.Items)
        {
           if (item.Equals(selectedItem))
           {
              item.Selected = true;
           }
        }
    }
