        hasClickEventHandler = HasEventHandler(buttonControl, "EventClick");
        Assert.AreEqual(hasClickEventHandler, true);
        
        private bool HasEventHandler(Control control, string eventName)
        {
            EventHandlerList events =
                (EventHandlerList)
                typeof(Component)
                 .GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance)
                 .GetValue(control, null);
            object key = typeof(Control)
                .GetField(eventName, BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
            Delegate handlers = events[key];
            return handlers != null && handlers.GetInvocationList().Any();
        }
