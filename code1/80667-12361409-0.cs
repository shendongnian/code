	public interface First { }
	public interface Second { }
	public class Processor : IRoot<int, double, int, double>
	{
		// Here we want 2 methods
		public int Process ( int item ) { System.Console.WriteLine ( "int Process" ); return item + 1; }
		public double Process ( double item ) { System.Console.WriteLine ( "double Process" ); return item + 10.748; }
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
			System.Console.ReadLine ();
		}
	}
