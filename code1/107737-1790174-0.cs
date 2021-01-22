	public class Test {
		public string Prop { get; private set; }
		public Test() {
			Prop = "abc";
		}
	}
    ....
	Test t = new Test();
	var pi = t.GetType().GetProperty("Prop");
	if(pi.CanRead) {
		Console.WriteLine(pi.GetValue(t, null));
	}
