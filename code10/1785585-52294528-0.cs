    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //Populate BankName for DropDown List
            MSAccessConnection dropdown = new MSAccessConnection();
            DataSet output = dropdown.PopulateDropdown("SELECT distinct([Bank]) FROM [BankDetails]");
            ddlBankName.DataTextField = output.Tables[0].Columns["Bank"].ToString();
            ddlBankName.DataValueField = output.Tables[0].Columns["Bank"].ToString();
            ddlBankName.DataSource = output.Tables[0];
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("Select", "All"));
        }
    }
