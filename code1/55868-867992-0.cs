    Button btn = new Button();
    EventInfo evt = btn.GetType().GetEvent("Click");
    MethodInfo handler = GetType().GetMethod("SomeHandler",
        BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    evt.AddEventHandler(btn, Delegate.CreateDelegate(
            evt.EventHandlerType, this, handler));
