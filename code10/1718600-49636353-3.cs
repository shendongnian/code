	public static class ExtensionMethods
	{
		public static IEnumerable<PropertyInfo> GetPropertiesInOrder<T>(this T This)
		{
			var type = typeof(T);
			var ctor = type.GetConstructors().Single();
			var parameters = ctor.GetParameters().OrderBy( p => p.Position );
			foreach (var p in parameters)
			{
				yield return type.GetProperty(p.Name);
			}
		}
	}
						
	public class Program
	{
		public static void Main()
		{
			var o = new { Id = 12, Name="Foo" };
			var list = o.GetPropertiesInOrder();
			foreach (var p in list)
			{
				Console.WriteLine("{0} {1}", p.PropertyType.Name, p.Name);
			}
		}
	}
