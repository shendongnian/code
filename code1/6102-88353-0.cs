    protected void CustomerView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        CustomerView.PageIndex = e.NewPageIndex;
        CustomerView.DataSource = Customer.GetAll();
        CustomerView.DataBind();
    }
