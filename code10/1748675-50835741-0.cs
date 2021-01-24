	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using zad8;
	namespace zad8
	{
		public abstract class CFormulas
		{
			abstract public double S();
			abstract public double P();
			abstract public double SF();
			abstract public double V();
		}
		public class CSquare : CFormulas
		{
			double a { get; set; }
			public CSquare(double a)
			{ this.a = a; }
			public override double S() { return a * a; }
			public override double P() { return 4 * a; }
			public override double SF()
			{
				throw new NotImplementedException();
			}
			public override double V()
			{
				throw new NotImplementedException();
			}
		}
		public class CRectangular : CFormulas
		{
			public double a { get; set; }
			public double b { get; set; }
			public CRectangular(double a, double b)
			{
				this.a = a;
				this.b = b;
			}
			public override double S() { return a * b; }
			public override double P() { return 2 * (a + b); }
			public override double SF()
			{
				throw new NotImplementedException();
			}
			public override double V()
			{
				throw new NotImplementedException();
			}
		}
		class CParallelepiped : CRectangular
		{
			public CParallelepiped(double a, double b, double h) : base(a, b) {
				this.h = h;
				this.a = a;
				this.b = b;
			}
			double h { get; set; }
			//public CParallelepiped(double h) { this.h = h; }
			public override double SF() { return 2 * (a*b+b*h+h*a); }
			
			public override double V() { return a*b* h; }
			public override string ToString() { return string.Format("Обема на фигурата е {0}", V()); }
		}
		class Program
		{
			static void Main(string [] args)
			{
				//CParallelepiped f3 = new CParallelepiped(1,2,3);
				//Console.WriteLine("Пълната повърхнина на паралелепипеда е {0}.", f3.SF());
				Console.ReadKey(true);
			}
		 }
	}
