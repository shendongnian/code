            for (int i = 1; i <= 260; i++)
            {
                ContentPlaceHolder maincontent = Page.Master.FindControl("MainContent") as ContentPlaceHolder;
                DropDownList a = (DropDownList)maincontent.FindControl("ddl" + i);
                a.DataSource = ds;
                a.DataTextField = "Options";
                a.DataValueField = "id";
                a.DataBind();
                a.Items.Insert(0, new ListItem("Select", "0", true));
            }
