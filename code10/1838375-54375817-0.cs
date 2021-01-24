	public class EventBus : ScriptableObject
	{
		public Event[] events;
	
		private Dictionary<Type, List<Delegate>> listeners
			= new Dictionary<Type, List<Delegate>>();
	
		public void Register<T>(Action<T> function) where T : Event
		{
			listeners[typeof(T)].Add(function);
		}
	
		public Action<T>[] Retrieve<T>() where T : Event
		{
			return listeners[typeof(T)].Cast<Action<T>>().ToArray();
		}
	}
