		System.Diagnostics.Stopwatch sw=new System.Diagnostics.Stopwatch();
		
		int a  = 5;
		string b = "5";
		
		sw.Start();
		
		for (int i=0;i<1000000;i++)
		{
			if(a == int.Parse(b))
			{
			
			} 
		}
		
		sw.Stop();
		Console.WriteLine("a == int.Parse(b) milliseconds: " + sw.ElapsedMilliseconds);
		
		sw.Reset();
		
		sw.Start();
		
		for (int i=0;i<1000000;i++)
		{
			if(a.ToString() == b)
			{
			
			}		
		}		
		
		sw.Stop();
		
		Console.WriteLine("a.ToString() == b milliseconds: " + sw.ElapsedMilliseconds);
