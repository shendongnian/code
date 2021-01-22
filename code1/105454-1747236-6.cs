    //This overload handles any type of EventHandler
    public static void SetAnyHandler<S, TDelegate, TArgs>(
        Func<EventHandler<TArgs>, TDelegate> converter, 
        Action<TDelegate> add, Action<TDelegate> remove,
        S subscriber, Action<S, TArgs> action)
        where TArgs : EventArgs
        where TDelegate : class
        where S : class
    {
        var subs_weak_ref = new WeakReference(subscriber);
        TDelegate handler = null;
        handler = converter(new EventHandler<TArgs>(
            (s, e) =>
            {
                var subs_strong_ref = subs_weak_ref.Target as S;
                if(subs_strong_ref != null)
                {
                    action(subs_strong_ref, e);
                }
                else
                {
                    remove(handler);
                    handler = null;
                }
            }));
        add(handler);
    }
    // this overload is simplified for generic EventHandlers
    public static void SetAnyHandler<S, TArgs>(
        Action<EventHandler<TArgs>> add, Action<EventHandler<TArgs>> remove,
        Subscriber, Action<S, TArgs> action)
        where TArgs : EventArgs
        where S : class
    {
        SetAnyHandler<EventHandler<TArgs>, TArgs>(
            h => new EventHandler<TArgs>(h),  //<-- Compiler warning here... WIP
            add, remove, subscriber, action);
    }
