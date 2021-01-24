      public class Program
    {
	public static void Main()
	{
		A a = new A0();
		a.CheckDerived();
		
	 }
    }
   
    class A0 : A {};
    class A1 : A {};
    class A2 : A {};
    class A {
    public void CheckDerived() {
        if(this.GetType().IsAssignableFrom(typeof(A0))) Console.Write("A0");
		if(this.GetType().IsAssignableFrom(typeof(A1))) Console.Write("A1");
		if(this.GetType().IsAssignableFrom(typeof(A2))) Console.Write("A2");
    }
    }
