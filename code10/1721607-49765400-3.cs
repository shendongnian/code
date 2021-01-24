	public class MyType<TData,TChild>
	{
		protected readonly TChild _child;
		protected readonly TData _data;
		
		public MyType(TData data, TChild child)
		{
			_data = data;
			_child = child;
		}
		
		public TChild Child
		{
			get
			{
				return _child;
			}
		}
		
		public TData Data
		{
			get
			{
				return _data;
			}
		}
	}
