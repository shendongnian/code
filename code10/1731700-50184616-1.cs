	class Big
	{
		public void Output(string text) { Console.WriteLine("Big - {0}", text); }
		
		public void CallingOutput()
		{
			Output("Outputting...");
		}
	}
	class Shim : Big
	{
		public new virtual void Output(string text) { base.Output(text); }
		
		public void CallingOutput()
		{
			Output("Outputting...");
		}
	}
