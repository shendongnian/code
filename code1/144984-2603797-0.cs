	internal interface IBaseInterface {
		string GetValue();
	}
	public abstract class MyBase : IBaseInterface {
		string IBaseInterface.GetValue()
		{ return "MyBase"; }
	}
	public class InheritedClass : MyBase {
		public void PrintValue(IBaseInterface someclass)
		{ Console.WriteLine(someclass.GetValue()); }
	}
