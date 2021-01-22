    // Declare the delegate - name it whatever you would like
    public delegate void ProcessCustomerInfoDelegate();
    // Instantiate the delegate and kick it off with BeginInvoke
    ProcessCustomerInfoDelegate d = new ProcessCustomerInfoDelegate(ProcessCustomerInfo); 
    simpleDelegate.BeginInvoke(null, null);
    
    // The method which will run Asynchronously
    void ProcessCustomerInfo()
    {
       // this is where you can call your webservice 50 times
    }
