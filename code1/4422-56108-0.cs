    class Program
	{
		static void Main(string[] args)
		{
			Collection<string> myitems = new Collection<string>();
			myMthod(ref myitems);
			Console.WriteLine(myitems.Count.ToString());
			Console.ReadLine();
		}
		static void myMthod(ref Collection<string> myitems)
		{
			myitems.Add("string");
			if(myitems.Count <5)
				myMthod(ref myitems);
		}
	}
