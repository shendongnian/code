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
