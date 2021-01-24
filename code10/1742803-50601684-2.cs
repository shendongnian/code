    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Refreshdata(214, DateTime.Today, DateTime.Today.AddDays(1).AddMinutes(-1));
        BindDropDownList();
       }else
       {
          if(int.TryParse(DropDownList1.SelectedValue, out int selectedProduct)) 
          {
             Refreshdata(selectedProduct, DateTime.Today, DateTime.Today.AddDays(1).AddMinutes(-1));   
          }
       }
    }
