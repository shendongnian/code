	public interface Second { }
	public interface Third { }
	public class Processor : IRoot<float, int, double, float, int, double>
	{
		// Here we want 3 methods
		public float Process ( float item ) { System.Console.WriteLine ( "  ...float Process..." ); return (float) (item - 55.75); }
		public int Process ( int item ) { System.Console.WriteLine ( "  ...int Process..." ); return item + 1; }
		public double Process ( double item ) { System.Console.WriteLine ( "  ...double Process..." ); return item + 10.748; }
		IProcess<int, int> IProcessWithDifferentiator<int, int, Second>.ConvertToBase ()
		{
			return new TP_Proxy<int, int, Second> ( this );
		}
		IProcess<double, double> IProcessWithDifferentiator<double, double, Third>.ConvertToBase ()
		{
			return new TP_Proxy<double, double, Third> ( this );
		}
	}
	public class TestProcessor : IRoot<int, int, int, int, int, int>
	{
		int IProcess<int, int>.Process ( int item )
		{
			System.Console.WriteLine ( "  ...int Process1..." ); return item - 11;
		}
		int IProcessWithDifferentiator<int, int, Second>.Process ( int item )
		{
			System.Console.WriteLine ( "  ...int Process2..." ); return item + 12;
		}
		int IProcessWithDifferentiator<int, int, Third>.Process ( int item )
		{
			System.Console.WriteLine ( "  ...int Process3..." ); return item + 100302;
		}
		IProcess<int, int> IProcessWithDifferentiator<int, int, Second>.ConvertToBase ()
		{
			return new TP_Proxy<int, int, Second> ( this );
		}
		IProcess<int, int> IProcessWithDifferentiator<int, int, Third>.ConvertToBase ()
		{
			return new TP_Proxy<int, int, Third> ( this );
		}
	}
	public interface IProcess<TResult, TItem>
	{
		TResult Process ( TItem item );
	}
	public interface IProcessWithDifferentiator<TResult, TItem, TDiff> // would love to ": IProcess<TResult, TItem>" here but won't work above
	{
		TResult Process ( TItem item ); // replicated method from IProcess... yuck(!)
		IProcess<TResult, TItem> ConvertToBase ();
	}
	// Having a proxy sucks.  But at least this proxy is shared among multiple classes implementing the IProcess concept.
	class TP_Proxy<TResult, TItem, TDiff> : IProcess<TResult, TItem>
	{
		public TP_Proxy ( IProcessWithDifferentiator<TResult, TItem, TDiff> px ) { _proxyTo = px; }
		private IProcessWithDifferentiator<TResult, TItem, TDiff> _proxyTo;
		TResult IProcess<TResult, TItem>.Process ( TItem item ) { return _proxyTo.Process ( item ); }
	}
	public interface IRoot<TR1, TR2, TR3, TItem1, TItem2, TItem3> :
		IProcess<TR1, TItem1>,
		IProcessWithDifferentiator<TR2, TItem2, Second>,
		IProcessWithDifferentiator<TR3, TItem3, Third>
	{
	}
	class Program
	{
		static void Main ( string [] args )
		{
			Processor p = new Processor ();
			// Direct conversion of first one, of course
			IProcess<float, float> a1 = p;
			System.Console.WriteLine ( "a1 .Process(3.3)   =    " + a1.Process ( (float) 3.3 ) );
			// Conversion of differentiated class
			IProcessWithDifferentiator<int, int, Second> a2 = ((IProcessWithDifferentiator<int, int, Second>) p);
			System.Console.WriteLine ( "a2d.Process(4)     =    " + a2.Process ( 4 ) );
			IProcessWithDifferentiator<double, double, Third> a3 = (IProcessWithDifferentiator<double, double, Third>) p;
			System.Console.WriteLine ( "a3d.Process(5.5)   =    " + a3.Process ( 5.5 ) );
			// Conversions to undifferentiated class using ugly proxies
			IProcess<int, int> a2u = ((IProcessWithDifferentiator<int, int, Second>) p).ConvertToBase ();
			System.Console.WriteLine ( "a2u.Process(4)     =    " + a2u.Process ( 4 ) );
			IProcess<double, double> a3u = ((IProcessWithDifferentiator<double, double, Third>) p).ConvertToBase ();
			System.Console.WriteLine ( "a3u.Process(5.5)   =    " + a3u.Process ( 5.5 ) );
			TestProcessor q = new TestProcessor ();
			IProcess<int, int> b1 = q;
			// Direct conversion of first one, of course
			System.Console.WriteLine ( "b1 .Process(3)     =    " + b1.Process ( 3 ) );
			// Conversion of differentiated class
			IProcessWithDifferentiator<int, int, Second> b2d = (IProcessWithDifferentiator<int, int, Second>) q;
			System.Console.WriteLine ( "b2d.Process(4)     =    " + b2d.Process ( 4 ) );
			IProcessWithDifferentiator<int, int, Third> b3d = (IProcessWithDifferentiator<int, int, Third>) q;
			System.Console.WriteLine ( "b3d.Process(5)     =    " + b3d.Process ( 5 ) );
			// Conversions to undifferentiated class using ugly proxies
			IProcess<int, int> b2u = ((IProcessWithDifferentiator<int, int, Second>) q).ConvertToBase ();
			System.Console.WriteLine ( "b2u.Process(4)     =    " + b2u.Process ( 4 ) );
			IProcess<int, int> b3u = ((IProcessWithDifferentiator<int, int, Third>) q).ConvertToBase ();
			System.Console.WriteLine ( "b3u.Process(5)     =    " + b3u.Process ( 5 ) );
			System.Console.ReadLine ();
		}
	}
