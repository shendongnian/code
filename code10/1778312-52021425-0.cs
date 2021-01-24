    public class Planet
    {
    	public Planet()
    	{
    		Moons = new HashSet<Moon>();
    	}
    	public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Moon> Moons { get; set; }
    }
    
    public class Moon
    {
    	public Moon()
    	{
    		Planet = new Planet();
    	}
    	public int ID { get; set; }
    	public int PlanetID { get; set; }
    	public string Name { get; set; }
    	public Planet Planet { get; set; }
    }
