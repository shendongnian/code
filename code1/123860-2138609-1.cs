    protected override void OnInit(EventArgs e)
    {
        myRepeater.ItemDataBound += myRepeater_ItemDataBound;
        base.OnInit(e);
    }
    
    void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // this method will be invoked once for every item that is data bound
        // this check makes sure you're not in a header or a footer
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // this is the single item being data bound, for instance, a user, if 
            // the data source is a List<User>
            User user = (User) e.Item.DataItem;
            // e.Item is your item, here you can find the controls in your template
            Literal myLiteral = (Literal) e.Item.FindControl("myLiteral");
            myLiteral.Text = user.Username + ", " + user.LastLoginDate.ToShortDateString();
            // you can add any amount of logic here
            // if you need to use it, e.Item.ItemIndex will tell you what index you're at
        }
    }
