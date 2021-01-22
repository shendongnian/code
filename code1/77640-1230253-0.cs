    EventArgs e = new EventArgs(myClassInstance);  // Create appropriate EventArgs
    MulticastDelegate eventDelagate = 
        this.GetType().GetField(theEventName + "Event",
        System.Reflection.BindingFlags.Instance | 
        System.Reflection.BindingFlags.NonPublic).GetValue(myClassInstance) as MulticastDelegate;
    Delegate[] delegates = eventDelagate.GetInvocationList();
    foreach (Delegate del in delegates) {  
          del.Method.Invoke(del.Target, new object[] { myClassInstance, e }); 
    }
