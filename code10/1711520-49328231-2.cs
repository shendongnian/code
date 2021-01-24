    public abstract class Class<T>
    {
	}
	
	public class ClassA : Class<ClassA>
	{
		static private int number = 7;
	}
	
	public class ClassB : Class<ClassB>
	{
		static private int number = 7;
		
		public ClassB()
		{
			ClassA.number = 5;  //Does not compile
			ClassB.number = 6;
		}
	}
	
	public class ClassC : Class<ClassC>
	{
		static private int number = 7;
		public ClassC()
		{
			Console.WriteLine(ClassA.number);  //Does not compile
			Console.WriteLine(ClassB.number);  //Does not compile
			Console.WriteLine(ClassC.number);  //Compiles
		}
	}
