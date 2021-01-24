	public class B: RegistryInstance<B>
	{
		public string Name { get; set; }
		public B(string name)
		{
			this.Name = name;
		}
	}
	public class A : RegistryInstance<A>
	{
		public string Name { get; set; }
		public A(string name)
		{
			this.Name = name;
		}
	}
	public abstract class RegistryInstance<T> where T:class
	{
		protected static readonly IDictionary<string, T> Registry = new Dictionary<string, T>();
		
		public static T GetInstance(string instanceName)
		{
			lock (Registry)
			{
				if (!Registry.TryGetValue(instanceName, out var newInstance))
				{
					newInstance = (T)Activator.CreateInstance(typeof(T), new object[] { instanceName });
				}
				return newInstance;
			}
		}
	}
