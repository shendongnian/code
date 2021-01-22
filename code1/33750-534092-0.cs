    //In CustomerSearchPresenter
    var presneter = new CustomerEditPresenter();
    var customerEditView = new CustomerEditView(presenter);
    presenter.SetCustomer(customer);
    //In CustomerEditPresenter
    public void SetCustomer(customer)
    {
        View.Name = customer.Name;
        View.Id = customer.Id;
        ...
    }
