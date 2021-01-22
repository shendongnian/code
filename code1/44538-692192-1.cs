    public void Page_Load()
    {
      if (!Page.IsPostBack)
      {
        this.Customers.DataSource = GetCustomers();
        this.Customers.DataBind();
      }
    }
    
    public void Customers_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
      if (e.CommandName == "Select")
      {
        if (e.Item.ItemType != ListViewItemType.DataItem)
          return;
        var customer = ((ListViewDataItem)e.Item).DataItem as Customer;
        if (customer != null)
        {
          // Now work directly with the customer object.
          Response.Redirect("viewCustomer.aspx?id=" + customer.Id);
        }
      }
    }
