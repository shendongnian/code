    private static void SetAnyGenericHandler<S, T>(
         Action<EventHandler<T>> add,     //to add event listener to publisher
         Action<EventHandler<T>> remove,  //to remove event listener from publisher
         S subscriber,                    //ref to subscriber (to pass to action)
         Action<S, T> action)             //called when event is raised
        where T : EventArgs
        where S : class
    {
        var subscriber_weak_ref = new WeakReference(subscriber);
        EventHandler<T> handler = null;
        handler = delegate(object sender, T e)
        {
            var subscriber_strong_ref = subscriber_weak_ref.Target as S;
            if(subscriber_strong_ref != null)
            {
                Console.WriteLine("New event received by subscriber");
                action(subscriber_strong_ref, e);
            }
            else
            {
                remove(handler);
                handler = null;
            }
        };
        add(handler);
    }
