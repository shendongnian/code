     var listeners = new TraceListener[Debug.Listeners.Count];
     Debug.Listeners.CopyTo(listeners, 0);
     foreach (var listener in listeners) {
        Debug.WriteLine("Name : {0} of type : {1}", listener.Name, listener.GetType());
     }
