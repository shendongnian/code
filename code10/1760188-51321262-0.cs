    public class SaveGame
	{
		public Player player { get; set; }
	}
	public class Player
	{
		public item[] friendshipData { get; set; }
	}
	public class item
	{
		public Key key { get; set; }
		public Friendship value { get; set; }
	}
	
    // add this class with a single string-field
	public class Key
	{
		public string @string { get; set;  }
	}
	public class Friendship
	{
		public int Points { get; set; }
	}
