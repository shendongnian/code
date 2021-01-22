        public delegate void CustomEventHandler(object sender, EventArgs e, string eventName);
        Delegate CreateEventHandler(EventInfo evt, CustomEventHandler d)
        {
            var handlerType = evt.EventHandlerType;
            var eventParams = handlerType.GetMethod("Invoke").GetParameters();
            //lambda: (object x0, EventArgs x1) => d(x0, x1)
            // This defines the incoming parameters of our dynamic method.  
            // The method signature will look something like this:
            // void dynamicMethod(object x0, EventArgs<T> x1)
            // Each parameter is dynamically determined via the 
            // EventInfo that was passed.
            var parameters = eventParams.Select((p, i) => Expression.Parameter(p.ParameterType, "x" + i)).ToArray();
            // Get the MethodInfo for the method we'll be invoking *within* our
            // dynamic method.  Since we already know the signature of this method,
            // we supply the types directly.
            MethodInfo targetMethod = d.GetType().GetMethod(
                "Invoke", 
                new Type[] { typeof(object), typeof(EventArgs), typeof(string) }
                );
            // Next, we need to convert the incoming parameters to the types
            // that are expected in our target method.  The second parameter,
            // in particular, needs to be downcast to an EventArgs object
            // in order for the call to succeed.
            var p1 = Expression.Convert(parameters[0], typeof(object));
            var p2 = Expression.Convert(parameters[1], typeof(EventArgs));
            var p3 = Expression.Constant(evt.Name);
            // Generate an expression that represents our method call.  
            // This generates an expression that looks something like:
            // d.Invoke(x0, x1, "eventName");
            var body = Expression.Call(
                Expression.Constant(d),
                targetMethod,
                p1,
                p2,
                p3
            );
            // Convert the entire expression into our shiny new, dynamic method.
            var lambda = Expression.Lambda(body, parameters.ToArray());
            // Convert our method into a Delegate, so we can use it for event handlers.
            return Delegate.CreateDelegate(handlerType, lambda.Compile(), "Invoke", false);
        }
