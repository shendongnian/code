public class Test
{
	public Test()
	{
	}
	// Always use the following constructor
	[InjectionConstructor]
	public Test(Type1 type1) : this()
	{
	}
	public Test(Type1 type1, Type2 type2) : this()
	{
	}
}
