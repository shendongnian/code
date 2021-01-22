    public partial Page{
        protected void rpParent_ItemDataBound(object sender, RepeaterEventArgs e){
            Item ParentItem = e.Item.DataItem as Item;
            Repeater rpChild = e.Item.FindControl("rpChild") as Repeater;
            rpChild.DataSource = context.SelectChildObjectsByParentId(ParentItem.Id);
            rpChild.DataBind();
        }
    }
