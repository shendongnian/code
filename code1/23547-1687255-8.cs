    SetAnyGenericHandler<Subscriber, ValueEventArgs<bool>>(
        h => publisher.EnabledChanged += h, 
        h => publisher.EnabledChanged -= h, 
        subscriber, 
        (s, e) => s.Enabled = e.Value);
