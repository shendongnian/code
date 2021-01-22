	public class Thing
	{
		int theInt;
		char theChar;
		DateTime theDateTime;
		
		public Thing(int theInt, char theChar, DateTime theDateTime)
		{
			this.theInt = theInt;
			this.theChar = theChar;
			this.theDateTime = theDateTime;
		}
		
		public string Dump()
		{
			return string.Format("I: {0}, S: {1}, D: {2}", 
				theInt, theChar, theDateTime);
		}
	}
	
	public class ThingCollection: List<Thing>
	{
		public delegate Thing AggregateFunction(Thing Best, 
							Thing Candidate);
		
		public Thing Aggregate(Thing Seed, AggregateFunction Func)
		{
			Thing res = Seed;
			foreach (Thing t in this) 
			{
				res = Func(res, t);
			}
			return res;
		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{
			Thing a = new Thing(1,'z',DateTime.Now);
			Thing b = new Thing(2,'y',DateTime.Now.AddDays(1));
			Thing c = new Thing(3,'x',DateTime.Now.AddDays(-1));
			Thing d = new Thing(4,'w',DateTime.Now.AddDays(2));
			Thing e = new Thing(5,'v',DateTime.Now.AddDays(-2));
			
			ThingCollection tc = new ThingCollection();
			
			tc.AddRange(new Thing[]{a,b,c,d,e});
			
			Thing result;
			//Max by date
			result = tc.Aggregate(tc[0], 
				delegate (Thing Best, Thing Candidate) 
				{ 
					return (Candidate.theDateTime.CompareTo(
						Best.theDateTime) > 0) ? 
						Candidate : 
						Best;  
				}
			);
			Console.WriteLine("Max by date: {0}", result.Dump());
			
			//Min by char
			result = tc.Aggregate(tc[0], 
				delegate (Thing Best, Thing Candidate) 
				{ 
					return (Candidate.theChar < Best.theChar) ? 
						Candidate : 
						Best; 
				}
			);
			Console.WriteLine("Min by char: {0}", result.Dump());				
		}
    }
