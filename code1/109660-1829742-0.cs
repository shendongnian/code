	[Serializable]
	public class RoundingAttribute : OnMethodBoundaryAspect
	{
		public override void OnExit(MethodExecutionEventArgs eventArgs)
		{
			base.OnExit(eventArgs);
			eventArgs.ReturnValue = Math.Round((double)eventArgs.ReturnValue, 2);
		}
	}
	class MyClass
	{
		public double NotRounded { get; set; }
		public double Rounded { [Rounding] get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var c = new MyClass
			        {
			        	Rounded = 1.99999, 
						NotRounded = 1.99999
			        };
			Console.WriteLine("Rounded = {0}", c.Rounded); // Writes 2
			Console.WriteLine("Not Rounded = {0}", c.NotRounded);  // Writes 1.99999
		}
	}
