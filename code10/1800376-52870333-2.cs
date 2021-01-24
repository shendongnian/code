    class Base
    {
    	static Dictionary<Type, int> counters = new Dictionary<Type, int>();
    	public Base()
    	{
    		if (!counters.ContainsKey(this.GetType()))
    			counters.Add(this.GetType(), 1);
    		else
    			counters[this.GetType()]++;
    		Console.WriteLine(this.GetType() + " " + counters[this.GetType()]);
    	}
    }
    class Derived : Base
    {
    }
    class Derived2 : Base
    {
    }
    public static void Main()
	{
		new Derived();
		new Derived2();
		new Derived();
	}
