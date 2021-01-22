	// VeryBaseClass is in an external assembly
	public abstract class VeryBaseClass
	{
		public VeryBaseClass(string className)
		{
			Console.WriteLine(className);
		}
	}
	// BaseClass and InheritedClass are in my assembly
	public abstract class BaseClass : VeryBaseClass
	{
		public BaseClass(string className)
			:
			base(className)
		{
		}
	}
	public class InheritedClass : BaseClass
	{
		public InheritedClass()
			: base(typeof(InheritedClass).Name)
		{
		}
	}
