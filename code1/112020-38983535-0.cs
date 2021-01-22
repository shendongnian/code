    using System;
	
	// order is approximately
	/*
	   1) most derived initializers first.
	   2) most base constructors first (or top-level in constructor-stack first.)
	*/
	public class Program
	{
		public static void Main()
		{
			var d = new D();
		}
	}
	
	public class A
	{
		public readonly C ac = new C("A");
	
		public A()
		{
			Console.WriteLine("A");
		}
		public A(string x) : this()
		{
			Console.WriteLine("A got " + x);
		}
	}
	
	public class B : A
	{
		public readonly C bc = new C("B");
		
		public B(): base()
		{
			Console.WriteLine("B");
		}
		public B(string x): base(x)
		{
			Console.WriteLine("B got " + x);
		}
	}
	
	public class D : B
	{
		public readonly C dc = new C("D");
		
		public D(): this("ha")
		{
			Console.WriteLine("D");
		}
		public D(string x) : base(x)
		{
			Console.WriteLine("D got " + x);
		}
	}
	
	public class C
	{
		public C(string caller)
		{
			Console.WriteLine(caller + "'s C.");
		}
	}
