    public void RegisterAction(ActionData actionData, EventInfo eventInfo, 
        Control control)
    {
        MethodInfo methodInfo = eventInfo.EventHandlerType.GetMethod("Invoke");
    
        List<Type> ps = new List<Type>();
        ps.Add  (typeof (ActionData)) ;
        foreach (ParameterInfo info in methodInfo.GetParameters())
        {
            ps.Add(info.ParameterType);
        }
    
         DynamicMethod method = new DynamicMethod("Adapter",
                                                  typeof (void),
                                                  ps.ToArray(),
                                                  GetType(), 
                                                  true);
    
         // compatible signatures for ExecuteAction
         // (assuming you aren't interested in sender and eventArgs):
         // static void ExecuteAction (ActionData) ;
         // void ActionData.ExecuteAction () ;
         MethodInfo miExecuteAction = <...> ;
         ILGenerator generator = method.GetILGenerator();
         generator.Emit (OpCodes.Ldarg_0) ;
         generator.Emit (OpCodes.Call, miExecuteAction) ;
         generator.Emit (OpCodes.Ret) ;
        
         // if you want to pass this to ExecuteAction, 
         // you'll need to put it into actionData.
         Delegate proxy = method.CreateDelegate(eventInfo.EventHandlerType, actionData);
    
         eventInfo.AddEventHandler(control, proxy);
    }
