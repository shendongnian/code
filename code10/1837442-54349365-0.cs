    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
          Property p = Property.GetPropertyById(id);
          PopulateForm(p);
          CreateJson(p);
        }
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Property p = Property.GetPropertyById(id);
        p.Price = txtPrice.Text.Trim();
    
        p.Save();
        CreateJson(p);
        PopulateForm(p);
    }
