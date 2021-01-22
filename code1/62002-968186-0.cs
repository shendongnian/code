    public abstract class BaseWrapper<TBaseType> 
		where TBaseType : class
	{
		protected readonly TBaseType BaseItem;
		protected BaseWrapper(TBaseType value)
		{
			BaseItem = value;
		}
		public bool IsNotNull()
		{
			return BaseItem != null;
		}
	}
