	class DataRowKeyAttribute : Attribute
	{
		private readonly string _Key;
		public string Key
		{
			get { return _Key; }
		}
		public DataRowKeyAttribute(string key)
		{
			_Key = key;
		}
	}
	
	
	static class DataTableExtensions
	{
		public static List<T> ToGenericList<T>(this DataTable datatable) where T : new()
		{
			return (from row in datatable.AsEnumerable()
					select Convert<T>(row)).ToList();
		}
		private static T Convert<T>(DataRow row) where T : new()
		{
			var result = new T();
			var type = result.GetType();
			foreach (var fieldInfo in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
			{
				var dataRowKeyAttribute = fieldInfo.GetCustomAttributes(typeof (DataRowKeyAttribute), true).FirstOrDefault() as DataRowKeyAttribute;
				if (dataRowKeyAttribute != null)
				{
					fieldInfo.SetValue(result, row[dataRowKeyAttribute.Key]);
				}
			} 
			
			return result;
		}
	}
	class EDog
	{
		[DataRowKey("IdDog")]
		private int intIdDog;
		[DataRowKey("IdOwner")]
		private int intIdOwner;
		[DataRowKey("Age")]
		private int intAge;
		[DataRowKey("Name")]
		private string strName;
		...	
	}
