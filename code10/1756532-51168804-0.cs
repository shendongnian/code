    public static RepaymentPlan GetRepaymentPlan(string customerId, string orderId)
    {
     var customerlist =_CustomerOrder.FindAll(c => c.CustomerId==customerId && c.orderId==orderId); 
     var pplist= new RepaymentPlan();
     if (customerlist.Any())
     {
         return pplist; 
     }
     return null;
    }
