    IInvoicingWorkflowProider p = (IInvoicingWorkflowProider)Factory.createInvoicingWorkflowProvider();
    
    ProxyFactory pf = new ProxyFactory(p);	//This is Spring's
    pf.AddAdvice(new TracingAspect());		//TracingAspect is my aspect implementation
    
    return (IInvoicingWorkflowProider)pf.GetProxy();
