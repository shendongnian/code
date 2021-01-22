    EventHandler e = typeof(ExternalClass)
		.GetField(nameof(ExternalClass.Event), BindingFlags.Instance | BindingFlags.NonPublic)
		.GetValue(instanceOfExternalClass) as EventHandler;
	if (e != null)
	{
		Delegate[] subscribers = e.GetInvocationList();
	}
