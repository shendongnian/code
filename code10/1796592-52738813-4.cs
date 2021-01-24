	public static void Detach(object obj, string eventName)
	{
		var caller = new StackTrace().GetFrame(1).GetMethod();
		var type = obj.GetType();
		foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
		{
			if (typeof(Delegate).IsAssignableFrom(field.FieldType))
			{
				var handler = (field.GetValue(obj) as Delegate)?.GetInvocationList().FirstOrDefault(m => m.Method.Equals(caller));
				if (handler != null)
				{
					type.GetEvent(eventName).RemoveEventHandler(obj, handler);
					return;
				}
			}
		}
	}
