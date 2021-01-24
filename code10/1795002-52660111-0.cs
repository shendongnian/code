        <asp:Repeater runat="server" id="Repeater1" OnItemDataBound="Repeater1_ItemDataBound">
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListItemType.AlternatingItem) || e.Item.ItemType.Equals(ListItemType.Item))
            {
                //You can hide/show disable/enable your div
                Control div1 = e.Item.FindControl("div1");
                //get role here and check 
                // if role != admin 
               div1.Visible = false;
            }
        }
