    void KickOffAsyncWebServiceCall(object sender, EventArgs e)
    {
        HelloService service = new HelloService();
        //Hookup async event handler
        service.HelloWorldCompleted += new 
            HelloWorldCompletedEventHandler(this.HelloWorldCompleted);
        service.HelloWorldAsync();
    }
    void HelloWorldCompleted(object sender,
                             HelloWorldCompletedEventArgs args)
    {
        //Display the return value
        Console.WriteLine (args.Result);
    }
