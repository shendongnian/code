    <asp:ListView ID="ListViewProducts" runat="server" DataSourceID="ProductsDataSource"
    OnItemDataBound="ListViewProducts_ItemDataBound" >
    ... ItemTemplate defines a link button called LinkButtonDoAdminStuff ...
    protected void ListViewProducts_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var myLinkButton = e.Item.FindControl("LinkButtonDoAdminStuff") as LinkButton;
        if (myLinkButton != null)
            myLinkButton.Visible = IsAdmin();
    }
