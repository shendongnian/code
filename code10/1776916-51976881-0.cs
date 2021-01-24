	void Main()
	{
		var foo = new Foo();
	
		Observable
			.FromEvent<AutoReadCallback, int>(a => (pd, l) =>
			{
				var r = pd.Length + l;
				a(r);
				return r;
			}, h => foo.AutoReadCallback += h, h => foo.AutoReadCallback -= h)
			.Subscribe(x => Console.WriteLine(x));
			
		foo.OnAutoReadCallback("Bar", 2);
	}
	
	public delegate int AutoReadCallback(string pData, int Len);
	
	public class Foo
	{
		public event AutoReadCallback AutoReadCallback;
		
		public int OnAutoReadCallback(string pData, int len)
		{
			var arc = this.AutoReadCallback;
			if (arc != null)
			{
				return arc(pData, len);
			}
			return -1;
		}
	}
