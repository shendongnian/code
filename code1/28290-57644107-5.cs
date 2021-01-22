    #if DEBUG
    private void CheckEventHasNoSubscribers(Delegate eventDelegate)
    {
        if (eventDelegate != null)
            if (eventDelegate.GetInvocationList().Length != 0)
            {
                var subscriberCount = eventDelegate.GetInvocationList().Length;
    
                // determine the consumers of this event
                var subscribers = new StringBuilder();
                foreach (var del in eventDelegate.GetInvocationList())
                    subscribers.AppendLine((subscribers.Length != 0 ? ", " : "") + del.Target);
    
                // throw an exception listing all current subscription that would hinder GC on them!
                throw new Exception(
                    $"Event:{eventDelegate.Method.Name} still has {subscriberCount} subscribers, with the following targets [{subscribers}]");
            }
    }
    
    #endif
