	using System;
	
	public class Program
	{
		public static void Main()
		{
			var a = new GenericTypeClass<TestType>();
			var b = new FormalClass(a);
			a.Name = "NameA";
			b.Name = "NameB";
			Console.WriteLine(a.Name);
			Console.WriteLine(b.Name);
		}
	}
	
	public class FormalClass
	{
		GenericTypeClass<TestType> _inner;
		public FormalClass(GenericTypeClass<TestType> parameter)
		{
			_inner = parameter;
		}
	
		public string Name
		{
			get
			{
				return _inner.Name;
			}
	
			set
			{
				_inner.Name = value;
			}
		}
	}
	
	public class GenericTypeClass<T>
		where T : class, IType
	{
		public string Name
		{
			get;
			set;
		}
	}
	
	public class TestType : IType
	{
	}
	
	public interface IType
	{
	}
