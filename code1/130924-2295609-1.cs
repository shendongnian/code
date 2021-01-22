	public class MyClass<TDerived> where TDerived:MyClass<TDerived>	{
		public static string MyStaticMethod() { return  typeof(TDerived).Name; }
	}
	public class MyOtherClass : MyClass<MyOtherClass> { }
	public class HmmClass:MyOtherClass { }
	
	void Main() {
		MyOtherClass.MyStaticMethod().Dump(); //linqpad says MyOtherClass
		HmmClass.MyStaticMethod().Dump();  //linqpad also says MyOtherClass
	}
