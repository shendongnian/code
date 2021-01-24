	Dictionary<Type, List<Delegate>> Subscribers = new Dictionary<Type, List<Delegate>>();
	void Main()
	{
		Subscribe<Evt>(ev => Console.WriteLine($"hello {ev.Message}"));
		IMessage m = new Evt("spender");
		foreach (var subscriber in Subscribers[m.GetType()])
		{
			subscriber?.DynamicInvoke(m);
		}
	}
	public void Subscribe<T>(Action<T> handler) where T : IMessage
	{
		if (!Subscribers.ContainsKey(typeof(T)))
		{
			Subscribers[typeof(T)] = new List<Delegate>();
		}
		Subscribers[typeof(T)].Add(handler);
	}
	public interface IMessage{}
	
	public class Evt : IMessage
	{
		public Evt(string message)
		{
			this.Message = message;
		}
		public string Message { get; }
	}
