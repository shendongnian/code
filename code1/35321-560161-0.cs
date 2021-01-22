	static void Main(string[] args)
	{
		var query = from m in Movies select m;
		var sorter = new Sorter<Movie>();
		sorter.AddSort("NAME", m => m.Name);
	}
	class Sorter<T>
	{
		public void AddSort(string name, Expression<Func<T, object>> func)
		{
			string fieldName = (func.Body as MemberExpression).Member.Name;
		}
	}
