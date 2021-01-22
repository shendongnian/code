    using System;
    struct Counter
    {
    	int value;
    	public override string ToString() {
    		value++;
    		return value.ToString();
    	}
    }
    class Program
    {
    	static void Test<T>() where T: new() {
    		T x = new T();
    		Console.WriteLine(x.ToString());
    		Console.WriteLine(x.ToString());
    		Console.WriteLine(x.ToString());
    	}
    	static void Main() {
    		Test<Counter>();
    	}
    }
