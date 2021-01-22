    public static void Link(Publisher publisher, Control subscriber) {
        var subscriber_weak_ref = new WeakReference(subscriber);
        EventHandler<ValueEventArgs<bool>> handler = null;
        handler = delegate(object sender, ValueEventArgs<bool> e) {
                var subscriber_strong_ref = subscriber_weak_ref.Target as Control;
                if (subscriber_strong_ref != null) subscriber_strong_ref.Enabled = e.Value;
                else {
                        ((Publisher)sender).EnabledChanged -= handler;
                        handler = null; 
                }
        };
        publisher.EnabledChanged += handler;
    }
