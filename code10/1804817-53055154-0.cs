	static class ExtensionMethods
	{
		public static string ToPascalCase(this string camelCase)
		{
			return string.IsNullOrEmpty(camelCase)
				? camelCase
				: camelCase.First().ToString().ToUpper() + camelCase.Substring(1);
		}
	}
	
	class BaseClass
	{
		public string Able { get; set; }
		public int Baker { get; set; }
		public DateTime Candy { get; set;}
		static public DerivedClass CreateDerived(BaseClass source)
		{
			var constructor = typeof(DerivedClass).GetConstructors()[0];
			var parameters = constructor.GetParameters();
			var arguments = parameters.Select
				(
					param => source
						.GetType()
						.GetProperty(param.Name.ToPascalCase())
						.GetValue(source, null)
				);
			var instance = constructor.Invoke(arguments.ToArray());
			Console.WriteLine("{0} arguments found", arguments.Count());
			return (DerivedClass)instance;
		}
	}
	class DerivedClass : BaseClass
	{
		public DerivedClass(string able, int baker, DateTime candy)
		{
			Able = able;
			Baker = baker;
			Candy = candy;
		}
	}
	public class Program
	{
		public static void Main()
		{
			var b = new BaseClass
			{
				Able = "Able!",
				Baker = 2,
				Candy = new DateTime(2018,10,31)
			};
			var d = BaseClass.CreateDerived(b);
			Console.WriteLine("Able={0} Baker={1} Candy={2}", d.Able, d.Baker, d.Candy);
		}
	}
