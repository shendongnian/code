     // machine A
     var event = new ManualResetEvent(false);
     B_Listener.OnChanged += delegate { event.Set(); }
     myDictionary.UpdateValue();
     event.WaitOne();
