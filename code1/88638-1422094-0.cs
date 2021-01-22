    ClickEditTestCustomer = new SimpleCommand
    {
        ExecuteDelegate = parameterValue =>
        {
            LayoutManager layoutManager = container.Resolve<LayoutManager>();
            layoutManager.DisplayViewAsPane("EditCustomer", "Edit Customer", new EditCustomerView());
        }
    };
    ClickEditTestCustomer = new SimpleCommand
    {
        ExecuteDelegate = parameterValue =>
        {
            LayoutManager layoutManager = container.Resolve<LayoutManager>();
            layoutManager.DisplayViewAsPane("EditCustomer", "Edit Customer", new EditCustomerView());
        }
    };
