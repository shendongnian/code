        List<ListItem> selection = new List<ListItem>();
        foreach (ListItem li in CheckBoxList1.Items)
        {
            if (li.Selected)
            {
                selection.Add(li);
                //string ch = li.Value;
            } 
        }
        Session["emp"] = selection;
        Response.Redirect("Page2.aspx");
        //Server.Transfer("Page2.aspx");
        
    }
