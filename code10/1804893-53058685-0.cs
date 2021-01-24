	public interface ITest
	{
		void Test();	
	}
	public class Program
	{
		public static void Main()
		{
			ITest nestedProgram = new NestedProgram();
			AnyOtherClass otherClass = new AnyOtherClass();
			otherClass.AnyMethod(nestedProgram);
		}
		private class NestedProgram : ITest
		{
			public void Test()
			{
				Console.WriteLine("Test method invoked");
			}
		}
	}
	public class AnyOtherClass
	{
		// won't compile
		// public void AnyMethod(Program.NestedProgram test)
		public void AnyMethod(ITest test)
		{
			// won't compile
			//ITest nestedProgram = new Program.NestedProgram();
			test.Test();
		}
	}
