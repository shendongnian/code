    public class Program
    {
    	public static void Main()
    	{
    		A a1 = new A();
    		A a2 = new A();
    		B b1 = new B();
    		ChildOfA coa = new ChildOfA();
    		Console.WriteLine("a1 hash={0}", Convert.ToBase64String(a1.GetId()));
    		Console.WriteLine("b1 hash={0}", Convert.ToBase64String(b1.GetId()));
    		Console.WriteLine("a2 hash={0}", Convert.ToBase64String(a2.GetId()));
    		Console.WriteLine("coa hash={0}", Convert.ToBase64String(coa.GetId()));
    	}
    }
