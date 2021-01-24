    void Main()
    {
    	var player = new Player();
    	var npc = new NPC();
    
    	var characters = new List<Character>(new Character[] { player, npc});
    	
    	foreach (var character in characters)
    	{
    		character.Draw();
    	}
    }
    
    abstract class Character
    {
    	public abstract string Image { get; }
    	
    	public abstract string Coordinate { get; }
    	
    	public void Draw()
    	{
    		Console.WriteLine($"Drawing Image {Image} at Coordinate {Coordinate}");
    	}
    }
    
    class NPC : Character
    {
    	public override string Image => "NPC IMAGE";
    
    	public override string Coordinate => "NPC Coordinate";
    }
    
    class Player : Character
    {
    	public override string Image => "PLAYER IMAGE";
    
    	public override string Coordinate => "PLAYER Coordinate";
    }
