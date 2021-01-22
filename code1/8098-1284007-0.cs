	volatile int foo;
	static void Main()
	{
		var test = new Test();
		new Thread(delegate() { Thread.Sleep(500); test.foo = 255; }).Start();
		test.foo = 0;
		while (test.foo != 255) ;
		Console.WriteLine("OK");
	}
}
