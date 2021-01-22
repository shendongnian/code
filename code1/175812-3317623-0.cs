    class UpdateCustomerDetailsViewModel
    {
        string OrderId;
        string DeliveryAddress;
    }
    
    public void SetCustomerDetails(int id, FormCollection form) 
    {
        var viewModel = new UpdateCustomerDetailsViewModel();
        UpdateModel(viewModel );
        IOrder = _repository.GetOrderById(id);
    
        ICustomer customer = IOrder.GetCustomerDetails(); 
    
        customer.UpdateDetails(viewModel.DeliveryAddress);
    
        _repository.SubmitChanges();
    }
