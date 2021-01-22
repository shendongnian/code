    public void BeginGetCustomerByID(Guid customerID)
    {
        // Second instance of customerID is userState
        service.GetCustomerByIDAsync(customerID, customerID);
    }
    private void service_GetCustomerByIDCompleted(object sender,
        GetCustomerByIDCompletedEventArgs e)
    {
        Guid customerID = (Guid)e.UserState;
        // Do something with e.Error or e.Result here
    }
