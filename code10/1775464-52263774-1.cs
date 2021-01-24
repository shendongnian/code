    override OnBindingContextChanged()
    {
    	if(BindingContext is CustomersViewModel customersViewModel)
    	{
    		customersViewModel.ScrollToCustomer = customer => CustomersListView.ScrollTo(customer);
    	}
    }
___
