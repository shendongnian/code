     using System;
     using System.Linq;
     using System.Linq.Expressions;
     using System.Reflection;
     class ExampleEventArgs : EventArgs
     {
        public int IntArg {get; set;}
     }
     class EventRaiser
     { 
         public event EventHandler SomethingHappened;
         public event EventHandler<ExampleEventArgs> SomethingHappenedWithArg;
         public void RaiseEvents()
         {
             if (SomethingHappened!=null) SomethingHappened(this, EventArgs.Empty);
             if (SomethingHappenedWithArg!=null) 
             {
                SomethingHappenedWithArg(this, new ExampleEventArgs{IntArg = 5});
             }
         }
     }
	
     class Handler
     { 
         public void HandleEvent() { Console.WriteLine("Handler.HandleEvent() called.");}
         public void HandleEventWithArg(int arg) { Console.WriteLine("Arg: {0}",arg);    }
     }
		
     static class EventProxy
     { 
         //void delegates with no parameters
         static public Delegate Create(EventInfo evt, Action d)
         { 
             var handlerType = evt.EventHandlerType;
             var eventParams = handlerType.GetMethod("Invoke").GetParameters();
 			  
             //lambda: (object x0, EventArgs x1) => d()
             var parameters = eventParams.Select(p=>Expression.Parameter(p.ParameterType,"x"));
             var body = Expression.Call(Expression.Constant(d),d.GetType().GetMethod("Invoke"));
             var lambda = Expression.Lambda(body,parameters.ToArray());
             return Delegate.CreateDelegate(handlerType, lambda.Compile(), "Invoke", false);
         }
         //void delegate with one parameter
         static public Delegate Create<T>(EventInfo evt, Action<T> d)
         {
             var handlerType = evt.EventHandlerType;
             var eventParams = handlerType.GetMethod("Invoke").GetParameters();
 			  
             //lambda: (object x0, ExampleEventArgs x1) => d(x1.IntArg)
             var parameters = eventParams.Select(p=>Expression.Parameter(p.ParameterType,"x")).ToArray();
             var arg    = getArgExpression(parameters[1], typeof(T));
             var body   = Expression.Call(Expression.Constant(d),d.GetType().GetMethod("Invoke"), arg);
             var lambda = Expression.Lambda(body,parameters);
             return Delegate.CreateDelegate(handlerType, lambda.Compile(), "Invoke", false);
         }
         //returns an expression that represents an argument to be passed to the delegate
         static Expression getArgExpression(ParameterExpression eventArgs, Type handlerArgType)
         {
            if (eventArgs.Type==typeof(ExampleEventArgs) && handlerArgType==typeof(int))
            {
               //"x1.IntArg"
               var memberInfo = eventArgs.Type.GetMember("IntArg")[0];
               return Expression.MakeMemberAccess(eventArgs,memberInfo);
            }
            throw new NotSupportedException(eventArgs+"->"+handlerArgType);
         }
     }
	
     static class Test
     {
         public static void Main()
         { 
            var raiser  = new EventRaiser();
            var handler = new Handler();
            //void delegate with no parameters
            string eventName = "SomethingHappened";
            var eventinfo = raiser.GetType().GetEvent(eventName);
            eventinfo.AddEventHandler(raiser,EventProxy.Create(eventinfo,handler.HandleEvent));
            //void delegate with one parameter
            string eventName2 = "SomethingHappenedWithArg";
            var eventInfo2 = raiser.GetType().GetEvent(eventName2);
            eventInfo2.AddEventHandler(raiser,EventProxy.Create<int>(eventInfo2,handler.HandleEventWithArg));
       
            //or even just:
            eventinfo.AddEventHandler(raiser,EventProxy.Create(eventinfo,()=>Console.WriteLine("!")));	
            eventInfo2.AddEventHandler(raiser,EventProxy.Create<int>(eventInfo2,i=>Console.WriteLine(i+"!")));
            raiser.RaiseEvents();
         }
     }
