    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    class EventRaiser
     { public event EventHandler SomethingHappened;
     }
	
    class Handler
     { public void HandleEvent() { /* ... */}
     }
		
    class EventProxy
     { static public Delegate Create(EventInfo evt, Action d)
        { var handlerType = evt.EventHandlerType;
	      var eventParams = handlerType.GetMethod("Invoke").GetParameters();
 			  
          var parameters = eventParams.Select(p=>Expression.Parameter(p.ParameterType,"x"));
          var body = Expression.Call(Expression.Constant(d),d.GetType().GetMethod("Invoke"));
          var lambda = Expression.Lambda(body,parameters.ToArray());
          return Delegate.CreateDelegate(handlerType, lambda.Compile(), "Invoke", false);
	    } 
	 }
		
    public static void attachEvent()
     { var raiser  = new EventRaiser();
       var handler = new Handler();
       string eventName = "SomethingHappened";
       var eventinfo = raiser.GetType().GetEvent(eventName);
       eventinfo.AddEventHandler(raiser,EventProxy.Create(eventinfo,handler.HandleEvent));			
     }
