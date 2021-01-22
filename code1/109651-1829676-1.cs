    interface MyControlInterface
    {
        void MyControlMethod();
    }
    
    class MyControl : Control, MyControlInterface
    {
        // Explicit interface member implementation:
        void MyControlInterface.MyControlMethod()
        {
            // Method implementation.
        }
    }
    class MyOtherControl : Control, MyControlInterface
    {
        // Explicit interface member implementation:
        void MyControlInterface.MyControlMethod()
        {
            // Method implementation.
        }
    }
    
    .....
    
    //Two instances of two Control classes, both implementing MyControlInterface
    MyControlInterface myControl = new MyControl();
    MyControlInterface myOtherControl = new MyOtherControl();
    
    //Declare the list as List<MyControlInterface>
    List<MyControlInterface> list = new List<MyControlInterface>();
    //Add both controls
    list.Add (myControl);
    list.Add (myOtherControl);
    
    //You can call the method on both of them without casting
    list[0].MyControlMethod();
    list[1].MyControlMethod();
