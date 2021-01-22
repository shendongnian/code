	static class FunnyExtension {
		public static string Double(this string str) { return str + str; }
		public static int Double(this int num) { return num + num; }
	}
	Func<string> aaMaker = "a".Double;
	Func<string, string> doubler = FunnyExtension.Double;
	Console.WriteLine(aaMaker());		//Prints "aa"
	Console.WriteLine(doubler("b"));	//Prints "bb"
