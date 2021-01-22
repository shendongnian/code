    //this delegate can be used to point to methods
    //which return void and take a string
    public delegate void MyEventHandler(string foo);
    
    //this event can cause methods which conform
    //to MyEventHandler to be called
    public event MyEventHandler SomethingHappened;
    //here is some code I want to be executed
    //when SomethingHappened fires
    void HandleSomethingHappened(string foo)
    {
        //do some stuff
    }
    //I am creating a delegate (pointer) to HandleSomethingHappened
    //and adding it to SomethingHappened's list of "Event Handlers"
    myObj.SomethingHappened += new MyEventHandler(HandleSomethingHappened);
