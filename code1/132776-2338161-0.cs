	public interface IProvideItem
	{
		object Get(int id);
	}
	
	public class JobDataProvider
		: IProvideItem
	{
		object IProvideItem.Get(int id)
		{
			return new Job();
		}
	}
	
	public class PersonDataProvider
		: IProvideItem
	{
		object IProvideItem.Get(int id)
		{
			return new Person();
		}
	}
	
	public class ItemDataProvider
	{
		private Dictionary<Type, IProvideItem> mProviders = new Dictionary<Type, IProvideItem>();
		public void RegisterProvider(Type type, IProvideItem provider)
		{
			mProviders.Add(type, provider);
		}
		
		public T Get<T>(int id)
		{
			return (T)mProviders[typeof(T)].Get(id);
		}
	}
	
	public class Job
	{
	}
	
	public class Person
	{
	}
