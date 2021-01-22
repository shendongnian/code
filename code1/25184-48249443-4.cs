		public class TestClass {
			public static void TestMethod() {
				var p = Process.GetCurrentProcess().Parent();
				Console.WriteLine("{0}", p.Id);
			}
		}
