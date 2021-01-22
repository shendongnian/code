    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 50; i++)
        {
            CheckBox _checkbox = new CheckBox();
            _checkbox.ID = "dynamicCheckListBox" + Convert.ToString(i);
            Panel1.Controls.Add(_checkbox);
    
            LiteralControl dynLabel = new LiteralControl("<Label id='fnameID" 
                + i + "' >test" + i + "</Label><br/>");
            dynLabel.ID = "fnameID" + i.ToString();
    
            Panel1.Controls.Add(dynLabel);
        }
    
    }
