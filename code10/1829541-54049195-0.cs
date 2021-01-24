         using (DataTable dt = getData(vCat, year, month))
      using (DataView dv = dt.DefaultView)
            {
        
                // THIS CODE ALSO WORKS..
                //ddlEstNo2.DataSource = dt;
                //ddlEstNo2.DataTextField = "estNo";
                //ddlEstNo2.DataValueField = "estNo";
                //ddlEstNo2.DataBind();
                //ddlEstNo2.Items.Insert(0, new ListItem("--Any--", ""));
                //ddlEstNo2.Items.Remove("Summary");
        
              
                
                    // populate ddlEstNo1
                    ddlEstNo1.DataSource = dv;
                    ddlEstNo1.DataTextField = "estNo";
                    ddlEstNo1.DataValueField = "estNo";
                    ddlEstNo1.DataBind();
                    ddlEstNo1.Items.Insert(0, new ListItem("--Any--", ""));
                    ddlEstNo1.Items.Remove("Summary");
        
                    // THIS CODE ALSO WORKS..
                    //ddlEstNo2.DataSource = dt;
                    //ddlEstNo2.DataTextField = "estNo";
                    //ddlEstNo2.DataValueField = "estNo";
                    //ddlEstNo2.DataBind();
                    //ddlEstNo2.Items.Insert(0, new ListItem("--Any--", ""));
                    //ddlEstNo2.Items.Remove("Summary");
                
        
                // populate ddlEstNo2 ==>>> doesnt work!
                ddlEstNo2.DataSource = dt;
                ddlEstNo2.DataTextField = "estNo";
                ddlEstNo2.DataValueField = "estNo";
                ddlEstNo2.DataBind();
                ddlEstNo2.Items.Insert(0, new ListItem("--Any--", ""));
                ddlEstNo2.Items.Remove("Summary");
        
            }
