	void Subscribe(object source, EventInfo ev)
	{
		var eventParams = ev.EventHandlerType.GetMethod("Invoke").GetParameters().Select(p => Expression.Parameter(p.ParameterType)).ToArray();
		var eventHandler = Expression.Lambda(ev.EventHandlerType,
			Expression.Call(
				instance: Expression.Constant(this),
				method: typeof(EventSubscriber).GetMethod(nameof(OnRaised), BindingFlags.NonPublic | BindingFlags.Instance),
				arg0: Expression.Constant(ev.Name),
				arg1: Expression.NewArrayInit(typeof(object), eventParams.Select(p => Expression.Convert(p, typeof(object))))),
			eventParams);
		ev.AddEventHandler(source, eventHandler.Compile());
	}
