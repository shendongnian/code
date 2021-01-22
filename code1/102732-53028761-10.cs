	internal class Program
	{
		private static void DoIt()
		{
			MyNamespace.MyValueType myValueType = default(MyNamespace.MyValueType);
			myValueType.A = 1;
			myValueType.B = 2;
			myValueType.C = 3;
			MyNamespace.Program.Print(myValueType); // The overload taking a value type.
			MyNamespace.MyValueType test = (MyNamespace.MyValueType)(object)myValueType; // ILSpy tries to understand the boxing operation as best as it can, but ends up boxing and unboxing, despite the IL only boxing (because C# boxes/unboxes by casting and cannot differentiate between the value type and boxed type).
			MyNamespace.Program.Print(test); // The overload taking the boxed type.
		}
		// The overload taking a value type.
		private static void Print(MyNamespace.MyValueType test)
		{
			Console.WriteLine(test.ToString());
			test.PrintA();
		}
		// The overload taking the boxed type.
		private static void Print(MyNamespace.MyValueType test)
		{
			Console.WriteLine(test.ToString());
			((MyNamespace.MyValueType)(object)test).PrintB();
			((MyNamespace.MyValueType)test).PrintB();
		}
	}
	[StructLayout(LayoutKind.Auto)]
	internal struct MyValueType
	{
		public int A;
		public int B;
		public int C;
		private void PrintA()
		{
			Console.WriteLine(A.ToString("x8"));
		}
		private void PrintB()
		{
			Console.WriteLine(B.ToString("x8"));
		}
	}
