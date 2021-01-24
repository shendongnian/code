	public class myClass
	{
	   public int score { get; set; }
	   public string name { get; set; }
	   public bool isAlive { get; set; }
	   public void Set(int score = -1, string name = null, bool? isAlive = null)
	   {
		   if (score != -1) this.score = score;
		   if (name != null) this.name = name;
		   if (isAlive.HasValue) this.isAlive = isAlive.Value;
	   }
	}
