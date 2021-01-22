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
    
    .....
    
    MyControlInterface myControl = new MyControl();
    List<MyControlInterface> list = new List<MyControlInterface>();
    list.Add (myControl);
    
    list[0].MyControlMethod();
