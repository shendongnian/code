    var container = doc.GetType().GetProperty("TextContainer", 
        BindingFlags.Instance | BindingFlags.NonPublic).GetValue(doc, null);
    var changedEvent = container.GetType().GetEvent("Changed", 
        BindingFlags.Instance | BindingFlags.NonPublic);
    EventHandler handler = range_Changed;
    var typedHandler = Delegate.CreateDelegate(changedEvent.EventHandlerType, 
        handler.Target, handler.Method);
    changedEvent.GetAddMethod(true).Invoke(container, new object[] { typedHandler });
