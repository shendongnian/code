    public abstract class Class<T>
	{
		private static int number = 5;  //Private now
	
		public void Print()
		{
			Console.WriteLine(number);  //Works
		}
	}
	
	public class ClassA : Class<ClassA>
	{
        //No number
	}
	
	public class ClassB : Class<ClassB>
	{
		public ClassB()
		{
			number = 1;  //Will not compile
		}
	}
	
	public class ClassC : Class<ClassC>
	{
		public ClassC()
		{
			number = ClassA.number;//Will not compile
		}
	}
	
