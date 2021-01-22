     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombo();
    
            }
        }
        public void BindCombo()
        {
            DropDownList1.Items.Clear();
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Insert(0, new ListItem("Select a Category", "select"));
            DropDownList1.SelectedValue = "select";
            DropDownList1.DataSourceID = "ds1";
            DropDownList1.DataBind();
            
        }
    
       protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //---- It can be placed in delete button's click event also ------//
            ds1.DeleteCommand = "Delete from Categories where CategoryID="+DropDownList1.SelectedValue;
            ds1.Delete();
            BindCombo();
            //---- It can be placed in delete button's click event also ------//
        }
