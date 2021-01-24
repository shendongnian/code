	class Trout : Fish 
	{
		public int size { get; set; }
	
		public override int Fitness()
		{
		    return size;
		}
	}
