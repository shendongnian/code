	public class DataFactory : IDataFactory
	{
		public DataTable Create(Type t)
		{
			if (t == typeof(FooData))
			{
				return SomethingThatReturnsClassAList().ToDataTable();
			}
			if (t == typeof(BarData))
			{
				return SomethingThatReturnsClassBList().ToDataTable();
			}
			return new List<dynamic>().ToDataTable();
		}
	}
