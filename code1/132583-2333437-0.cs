            Dictionary<string, int> myList = new Dictionary<string, int>();
            myList.Add("Jan", 1);
            myList.Add("Feb", 2);
            System.Web.UI.WebControls.DropDownList drodown = new System.Web.UI.WebControls.DropDownList();
            drodown.DataSource = myList;
            drodown.DataTextField = "key";
            drodown.DataValueField = "value";
            drodown.DataBind();
            int monthValue = int.Parse(drodown.SelectedValue);
