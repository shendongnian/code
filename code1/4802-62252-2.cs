    enum Responses { Yes = 1, No = 2, Maybe = 3 }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (int value in Enum.GetValues(typeof(Responses)))
            {
                DropDownList1.Items.Add(new ListItem(Enum.GetName(typeof(Responses), value), value.ToString()));
            }
        }
    }
