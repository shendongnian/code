    void Main()
    {
    	var song = new Song("Thunderstruck", 15, "AC/DC Records",
    		123
    	); 
    	var songAwesome = new Song(song);
    	songAwesome.Name.Dump();
    	songAwesome.Name = "Big Gun"; //This line fails because the property is redonly
    	
    }
    
    public class Song
    {
    
    	public string Name { get; } //readonly props in C# 6.0
    	public double Price { get;}
    	public string Owner { get; }
    	public int Id { get; }
    	
    	public Song(Song song) : this(song.Name, song.Price, 
    	song.Owner, song.Id){
    		
    	} //Let us have a copy constructor just for the fun of it
    
    	public Song(string name, double price, string owner, int id)
    	{
    		this.Name = name;
    		this.Price = price;
    		this.Owner = owner;
    		this.Id = id;
    	}
    }
    
    
    // Define other methods and classes here
