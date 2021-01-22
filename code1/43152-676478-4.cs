    public static void Execute<T> (ActionData data, object sender, T args)
        where T : EventArgs
    {
        ExecuteAction (data) ;
    }
    public void RegisterAction (ActionData actionData, EventInfo eventInfo, 
        Control control)
    {
        MethodInfo compatibleMethod = typeof (this).GetMethod ("Execute",
            BindingFlags.Static | BindingFlags.Public).MakeGenericMethod (
            eventInfo.EventHandlerType.GetMethod ("Invoke").GetParameters ()[1])) ;
        eventInfo.AddEventHandler (control, 
            Delegate.CreateDelegate (eventInfo.EventHandlerType, actionData,
            compatibleMethod)) ;
    }
