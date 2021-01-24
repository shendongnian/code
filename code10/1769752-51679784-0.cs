	public class MyDataRowAttribute : DataRowAttribute, ITestDataSource
	{
		public MyDataRowAttribute(object data1) : base(data1)
		{ }
		public MyDataRowAttribute(object data1, params object[] moreData) : base(data1, moreData)
		{ }
		public new IEnumerable<object[]> GetData(MethodInfo methodInfo)
		{
			var parameters = methodInfo.GetParameters();
			object[] args = new object[parameters.Length];
			for (int i = 0; i < args.Length; i++)
			{
				if (i < base.Data.Length)
				{
					args[i] = base.Data[i];
				}
				else if (parameters[i].HasDefaultValue)
				{
					args[i] = parameters[i].DefaultValue;
				}
				else
				{
					throw new ArgumentException("Not enough arguments provided");
				}
			}
			return new List<object[]> { args };
		}
	}
