C#
using System;
				
public class Program
{
	public class Base
	{
		public string Name { get; set; }
		public string VarName { get; set; }
		
		public override bool Equals(object o)
		{
			return object.ReferenceEquals(this, o) 
				|| o.GetType()==this.GetType() && ThisEquals(o);
		}
		
		protected virtual bool ThisEquals(object o)
		{
			Base b = o as Base;
			return b != null
				&& (Name == b.Name);
		}
		
		public override string ToString()
		{
			return string.Format("[{0}@{1} Name:{2}]", GetType(), VarName, Name);
		}
		
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
	
	public class Derived : Base
	{
		public int Age { get; set; }
		
		protected override bool ThisEquals(object o)
		{
			var d = o as Derived;
			return base.ThisEquals(o)
				&& d != null
				&& (d.Age == Age);
		}
		
		public override string ToString()
		{
			return string.Format("[{0}@{1} Name:{2} Age:{3}]", GetType(), VarName, Name, Age);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Age.GetHashCode();
		}
	}
	
	public static void Main()
	{
		var b1 = new Base { Name = "anna", VarName = "b1" };
		var b2 = new Base { Name = "leo", VarName = "b2" };
		var b3 = new Base { Name = "anna", VarName = "b3" };
		var d1 = new Derived { Name = "anna", Age = 21, VarName = "d1" };
		var d2 = new Derived { Name = "anna", Age = 12, VarName = "d2" };
		var d3 = new Derived { Name = "anna", Age = 21, VarName = "d3" };
		
		var all = new object [] { b1, b2, b3, d1, d2, d3 };
		
		foreach(var a in all) 
		{
			foreach(var b in all)
			{
				Console.WriteLine("{0}.Equals({1}) => {2}", a, b, a.Equals(b));
			}
		}
	}
}
