	public interface First { }
	public interface Second { }
	public class Processor : IRoot<int, double, int, double>
	{
		// Here we want 2 methods
		public int Process ( int item ) { System.Console.WriteLine ( "int Process" ); return item + 1; }
		public double Process ( double item ) { System.Console.WriteLine ( "double Process" ); return item + 10.748; }
	}
	public class TestProcessor : IRoot<int, int, int, int>
	{
		int IProcessWithDifferentiator<int, int, First>.Process ( int item )
		{
			System.Console.WriteLine ( "int Process" ); return item + 1;
		}
		int IProcessWithDifferentiator<int, int, Second>.Process ( int item )
		{
			System.Console.WriteLine ( "int Process" ); return item + 100302;
		}
	}
	public interface IProcessWithDifferentiator<TResult, TItem, TDiff>
	{
		TResult Process ( TItem item );
	}
	public interface IRoot<TR1, TR2, TItem1, TItem2> :
		IProcessWithDifferentiator<TR1, TItem1, First>,
		IProcessWithDifferentiator<TR2, TItem2, Second>
	{
	}
	class Program
	{
		static void Main ( string [] args )
		{
			Processor p = new Processor ();
			IProcessWithDifferentiator<int, int, First> one = p;
			System.Console.WriteLine ( "one.Process(4) = " + one.Process ( 4 ) );
			IProcessWithDifferentiator<double, double, Second> two = p;
			System.Console.WriteLine ( "two.Process(5.5) = " + two.Process ( 5.5 ) );
			TestProcessor q = new TestProcessor ();
			IProcessWithDifferentiator<int, int, First> q1 = q;
			System.Console.WriteLine ( "q1.Process(4) = " + q1.Process ( 4 ) );
			IProcessWithDifferentiator<int, int, Second> q2 = q;
			System.Console.WriteLine ( "q2.Process(5) = " + q2.Process ( 5 ) );
			System.Console.ReadLine ();
		}
	}
