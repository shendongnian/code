    public static void UnregisterAllEvents(object objectWithEvents)
    {
        Type theType = objectWithEvents.GetType();
    
        //Even though the events are public, the FieldInfo associated with them is private
        foreach (System.Reflection.FieldInfo field in theType.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
        {
            //eventInfo will be null if this is a normal field and not an event.
            System.Reflection.EventInfo eventInfo = theType.GetEvent(field.Name);
            if (eventInfo != null)
            {
                MulticastDelegate multicastDelegate = field.GetValue(objectWithEvents) as MulticastDelegate;
                if (multicastDelegate != null)
                {
                    foreach (Delegate _delegate in multicastDelegate.GetInvocationList())
                    {
                        eventInfo.RemoveEventHandler(objectWithEvents, _delegate);
                    }
                }
            }
        }
    }
