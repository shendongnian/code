        ...
            protected void saveRecord(object sender, EventArgs e)
            {
                LinkButton lb = (LinkButton)sender;
                string ROW_ID = (string)lb.CommandName;
                string DD_ID = (string)lb.CommandArgument;
                Response.Write("<script>alert('Hello');</script>");
                ...
            }
                
            protected void Page_Load(object sender, EventArgs e)
            {
                ...
            
                saveButton.CommandName = "1a";
                saveButton.CommandArgument = "StatusDD";
                saveButton.Click += new EventHandler(saveRecord);
                ...
            }
        }
