    private static void InvokeMyMethod() 
    { 
        ServiceClient service = new MyService.ServiceClient(); 
 
        try 
        { 
            service.MyMethod(); 
        } 
        catch (System.ServiceModel.FaultException<InvalidRoutingCodeFault> ex) 
        { 
            // This will output the "Message" property of the System.ServiceModel.FaultException
            // 'The creator of this fault did not specify a Reason' if not specified when thrown
            Console.WriteLine("faultException Message: " + ex.Message);    
            // This will output the ErrorMessage property of your InvalidRoutingCodeFault type
            Console.WriteLine("InvalidRoutingCodeFault Message: " + ex.Detail.ErrorMessage);    
        } 
    }
