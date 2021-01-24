	using System;
	public class Program
	{
		public static void Main()
		{
			var rv = new ReturnValues
			{
				Boolean = true,
				Double = 20.1,
				String = "myString"
			};
			Console.WriteLine(ReturnValueMatchedType<bool>(rv));
			Console.WriteLine(ReturnValueMatchedType<Double>(rv));
			Console.WriteLine(ReturnValueMatchedType<string>(rv));
		}
		public class ReturnValues
		{
			public bool Boolean { get; set; }
			public Double Double { get; set; }
			public string String { get; set; }
		}
		public static T ReturnValueMatchedType<T>(ReturnValues v)
		{
		  var typeCode = Type.GetTypeCode(typeof(T));
		  switch( typeCode )
		  {
			case TypeCode.Boolean:
				  return (T)(object)v.Boolean;
			case TypeCode.Double:
				  return (T)(object)v.Double;
			case TypeCode.String:
				  return (T)(object)v.String;
			default:
				return default(T);			
		  }
		}
	}
