    // this is helper collection.
    // there are all wrapper objects
    // , which should not be collected by GC
    private List<object> holdedObjects = new List<object>();
    
    // hooks necesary events
    void HookEvents() {
        // finds button in commandbars
        CommandBarButton btnSomeButton = FindCommandBarButton( "MyButton ");
        // hooks "Click" event
        btnSomeButton.Click += btnSomeButton_Click;
        // add "btnSomeButton" object to collection and
        // and prevent themfrom collecting by GC
        holdedObjects.Add( btnSomeButton );
    }
