    // create your client
    ICustomer channel = CreateCustomerClient();
    
    try
    {
       // use it
       channel.GetCustomerDetails() ....
 
       (more calls)
    
       // close it
       channel.Close();
    }
    catch(CommunicationException commEx)
    {
       // a CommunicationException probably indicates something went wrong 
       // when closing the channel --> abort it
       channel.Abort();
    }
