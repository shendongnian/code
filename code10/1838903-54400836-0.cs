    private Order GenerateOrderID(Order order)
    {
        try
        {
            order = new Order(); // note this line
            order.Id = Guid.NewGuid().ToString();
            order.SubmittedOn = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");                
            return order;
        }
        catch(Exception ex)
        {            
            throw;
        }
    }
