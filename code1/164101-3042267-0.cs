    <asp:Repeater id="unorderedList" runat="server" OnItemDataBound="unorderedList_ItemDataBound">
       <HeaderTemplate>
           <ul>
       </HeaderTemplate>
       <ItemTemplate>
              <li><asp:Literal id="myItem" runat="server" /></li>
       </ItemTemplate>
       <FooterTemplate>
           </ul>
       </FooterTemplate>
    </asp:Repeater>
...
    private void Page_Init(object sender, EventArgs e)
    {
        string[] array = { "Apple", "Banana", "Cherry" };
        unorderedList.DataSource = array;
        unorderedList.DataBind();
    }
    protected void unorderedList_ItemDataBound(object sender,  RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            string itemValue = (string)e.Item.DataItem;
            Literal myItem = (Literal)e.Item.FindControl("myItem");
            myItem.Text = itemValue;
        }
    }
