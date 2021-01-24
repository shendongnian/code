	public class Program
	{
		public static void Main()
		{
			IMyFactory<BaseType> factory;
			{
				factory = new MyFactory<BaseType>();
				var instance = factory.Resolve();
				Console.WriteLine(instance.GetType().FullName);
			}
			{
				factory = new MyFactory<DerivedType>() as IMyFactory<BaseType>;
				var instance = factory.Resolve();
				Console.WriteLine(instance.GetType().FullName);
			}
		}
	}
