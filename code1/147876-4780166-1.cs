    //Call This function from Page_Load Event
    private void CustomizeRV(System.Web.UI.Control reportControl)
    {
        foreach (System.Web.UI.Control childControl in reportControl.Controls)
        {
            if (childControl.GetType() == typeof(System.Web.UI.WebControls.DropDownList)) 
            { 
                System.Web.UI.WebControls.DropDownList ddList = (System.Web.UI.WebControls.DropDownList)childControl;
                ddList.PreRender += new EventHandler(ddList_PreRender); 
            }
            if (childControl.Controls.Count > 0) 
            { 
                CustomizeRV(childControl); 
            } 
        }
    }
    
    //Dropdown prerender event
    //You can hide any option from ReportViewer( Excel,PDF,Image )   
    void ddList_PreRender(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(System.Web.UI.WebControls.DropDownList))
        {
            System.Web.UI.WebControls.DropDownList ddList = (System.Web.UI.WebControls.DropDownList)sender; 
            System.Web.UI.WebControls.ListItemCollection listItems = ddList.Items;
    
            if ((listItems != null) && (listItems.Count > 0) && (listItems.FindByText("Excel") != null))
            {
                foreach (System.Web.UI.WebControls.ListItem list in listItems)
                {
                    if (list.Text.Equals("Excel"))
                    {
                        list.Enabled = false;
                    }
                }
            }
        }
    }
