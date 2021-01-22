        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !Page.IsCallback)
            {
                // some example data
                MyDataList.DataSource = new[] {
                    new { ID = 1, NAME = "ABCD" },
                    new { ID = 2, NAME = "BCDE" },
                    new { ID = 3, NAME = "CDEF" },
                };
                MyDataList.DataBind();
            }
        }
        protected void MyDataList_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            // all of the buttons within the row can cause this event handler to execute.
            // Use the CommandName argument (populated by the CommandName property of the button that was clicked) in order to determine which button was clicked and take the appropriate action
            switch (e.CommandName)
            {
                case "Edit":
                    // ...
                    break;
                case "Update":
                    // ...
                    break;
                case "Cancel":
                    // ...
                    break;
                case "Delete":
                    // ...
                    break;
                case "MyCommand":
                    // update your label using the command argument rather that the button's ToolTip
                    MyLabel.Text = e.CommandArgument.ToString();
                    TextBox txtInput1 = e.Item.FindControl("txtInput1") as TextBox;
                    TextBox txtInput2 = e.Item.FindControl("txtInput2") as TextBox;
                    string value1 = txtInput1.Text;
                    string value2 = txtInput2.Text;
                    // do something with the input values
                    break;
                case "Do Something Crazy!":
                    // ...
                    break;
            }
        }
