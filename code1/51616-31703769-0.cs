    //This delegate can be used to point to methods
    //which return void and take a string.
    public delegate void MyDelegate(string foo);
    
    //This event can cause any method which conforms
    //to MyEventHandler to be called.
    public event MyDelegate MyEvent;
    
    //Here is some code I want to be executed
    //when SomethingHappened fires.
    void MyEventHandler(string foo)
    {
        //Do some stuff
    }
    
    //I am creating a delegate (pointer) to HandleSomethingHappened
    //and adding it to SomethingHappened's list of "Event Handlers".
    myObj.MyEvent += new MyDelegate (MyEventHandler);
