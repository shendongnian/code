    MyObj legacyComObject = new MyObj();
    // The following code assumes other COM objects have already subscribed to the 
    // MyObj class's Message event at this point.
    //
    // NOTE: VB6 objects have two hidden interfaces for classes that raise events:
    //
    // _MyObj (with one underscore): The default interface.
    // __MyObj (with two underscores): The event interface.
    //
    // We want the second interface, because it gives us a delegate
    // that we can use to raise the event.
    // The ComEventUtils.GetEventSinks<T> method is a convenience method
    // that returns all the objects listening to events from the legacy COM object.
    
    // set up the params for the event
    string messageData = "Hello, world!";
    bool cancel = false;
    // raise the event by invoking the event delegate for each connected object...
    foreach(__MyObj sink in ComEventUtils.GetEventSinks<__MyObj>(legacyComObject))
    {
        // raise the event via the event delegate
        sink.Message(messageData, ref cancel);
        if(cancel == true)
        {
            // do cancel processing (just an example)
            break;
        }
    }
