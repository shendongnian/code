    //WCF Service
    public decimal GetTotalForOrder(Order newOrder, RunTimeClass runtimeValue)
    {   
        //I would like to pass the runtimeValue when resolving the IOrderCalculator depedency using a dictionary or something
        //Something like this ObjectFactory.Resolve(runtimeValue);
        IOrderCalculator calculator = ObjectFactory.Resolve();    
        return calculator.CalculateOrderTotal(newOrder);    
    }
