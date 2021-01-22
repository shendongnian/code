csharp
public static class EnumerableExtensions {
	internal static Func<TClass, object> CompileGetter<TClass>(string propertyName) {
		var param = Expression.Parameter(typeof(TClass));
		var body = Expression.Convert(Expression.Property(param, propertyName), typeof(object));
		return Expression.Lambda<Func<TClass, object>>(body,param).Compile();
	}     
	public static DataTable ToDataTable<T>(this IEnumerable<T> collection) {
		var dataTable = new DataTable();
		var properties = typeof(T)
						.GetProperties(BindingFlags.Public | BindingFlags.Instance)
						.Where(p => p.CanRead)
						.ToArray();
		if (properties.Length < 1) return null;
		var getters = new Func<T, object>[properties.Length];
		for (var i = 0; i < properties.Length; i++) {
			var columnType = Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType;
			dataTable.Columns.Add(properties[i].Name, columnType);
			getters[i] = CompileGetter<T>(properties[i].Name);
		}
		foreach (var row in collection) {
			var dtRow = new object[properties.Length];
			for (var i = 0; i < properties.Length; i++) {
				dtRow[i] = getters[i].Invoke(row) ?? DBNull.Value;
			}
			dataTable.Rows.Add(dtRow);
		}
		return dataTable;
	}
}
Only works with properties (not fields) but it works on Anonymous Types. 
  [1]: https://github.com/mgravell/fast-member
  [2]: https://github.com/vexe/Fast.Reflection/blob/master/FastReflection.cs
