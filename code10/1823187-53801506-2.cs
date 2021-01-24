	public class myClass
	{
	   public int score { get; set; }
	   public string name { get; set; }
	   public bool isAlive { get; set; }
       public myClass SetScore(int score)
       {
           this.score = score;
           return this;
       }
       public myClass SetName(string name)
       {
           this.name = name;
           return this;
       }
       public myClass SetIsAlive(bool isAlive)
       {
           this.isAlive = isAlive;
           return this;
       }
	}
