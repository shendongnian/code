    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==       ListItemType.AlternatingItem)
        {
            // Show or hid div here
            System.Web.UI.HtmlControls.HtmlContainerControl div1 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("div1");
            System.Web.UI.HtmlControls.HtmlContainerControl div2 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("div2");
            System.Web.UI.HtmlControls.HtmlContainerControl div3 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("div3");
        
    Also changed the test for the reader.
    the reader is checking the DB for a RoleId but the problem was when the reader
