    public class TestClass1
	{
		public string a = "test1";
	}
    public static void ArrayCopyClone()
	{
		TestClass1 tc1 = new TestClass1();
		TestClass1 tc2 = new TestClass1();
		TestClass1[] arrtest1 = { tc1, tc2 };
		TestClass1[] arrtest2 = new TestClass1[arrtest1.Length];
		TestClass1[] arrtest3 = new TestClass1[arrtest1.Length];
		arrtest1.CopyTo(arrtest2, 0);
		arrtest3 = arrtest1.Clone() as TestClass1[];
		Console.WriteLine(arrtest1[0].a);
		Console.WriteLine(arrtest2[0].a);
		Console.WriteLine(arrtest3[0].a);
		arrtest1[0].a = "new";
		Console.WriteLine(arrtest1[0].a);
		Console.WriteLine(arrtest2[0].a);
		Console.WriteLine(arrtest3[0].a);
	}
    
    /* Output is 
    test1
    test1
    test1
    new
    new
    new */
