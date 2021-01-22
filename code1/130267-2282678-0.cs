	public static class DataTableExtensions
	{
		public static List<T> ToGenericList<T>(this DataTable datatable, Func<DataRow, T> converter)
		{
			return (from row in datatable.AsEnumerable()
					select converter(row)).ToList();
		}
	}
	class EDog
	{
		private int intIdDog;
		private int intIdOwner;
		private int intAge;
		private string strName;
		...
		public static EDog Converter(DataRow row)
		{
			return new EDog
							{
								intIdDog = (int)row["IdDog"],
								intIdOwner = (int)row["IdOwner"],
								intAge = (int)row["Age"],
								strName = row["Name"] as string
							};
		}
	}
