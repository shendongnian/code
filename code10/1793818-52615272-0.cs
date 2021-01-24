	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	public class VehicleAttribute : Attribute
	{
		public string Color { get; }
		public int NumWheels { get; }
		public VehicleAttribute(string color, int numWheels)
		{
			Color = color;
			NumWheels = numWheels;
		}
	}
	[Vehicle("Yellow", 6)]
	public class Bus
	{ 
		[Vehicle("Blue", 5)]
		public string Name { get; set; }
	}
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine(Test<Bus, VehicleAttribute>((x) => x.Name).Color);
		}
		static U Test<T, U>(Expression<Func<T, object>> expr) where U : Attribute
		{
			if(!(expr.Body is MemberExpression memberExpr))
			{
				throw new NotSupportedException("expr");
			}
			return (U)memberExpr.Member.GetCustomAttribute(typeof(U), false);
		}
	}
