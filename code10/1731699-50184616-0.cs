    //Original, unmodifiable class
	class Big
	{
		public void Output(string text) { Console.WriteLine("Big - {0}", text); }
	}
    //This class is exactly the same as a Big, but with Output declared as virtual
	class Shim : Big
	{
		public new virtual void Output(string text) { base.Output(text); }
	}
	
    //Now we can override Output
	class Small : Shim
	{
		public override void Output(string text) { Console.WriteLine("Small - {0}", text); }
	}
