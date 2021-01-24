    public class PlayerIndex1Model
    {
    	[Key]
    	public int Id { get; set; }
    	
    	//Why this ???
    	public List<Player> Players { get; set; } 
    
    	public string PlayerName { get; set; }
    	public int PlayerWeight { get; set; }
    	public string PlayerSurname { get; set; }
    	public DateTime Birthday { get; set; }
    	public string PlayerPosition { get; set; }
    	public decimal PlayerHeight { get; set; }
    
    	public string ClubName { get; set; }
    
    
    	
    	[ForeignKey("BasketBallClub")]
    	public int BasketBallClubId { get; set; }
    	public virtual BasketBallClub BasketBallClub
    	{
    		get; set;
    	}
    }
    
    public class BasketBallClub
    {
    	[Key]
    	public int Id { get; set; }
    	public string ClubName { get; set; }
        public virtual ICollection<Player> Players { get; set; } 
    }
    public ActionResult Index1()
    {
    	List<Player> playerList =  new List<Player>();
    	
    	BasketDbContext db = new BasketDbContext();
        List<Player> playerList = db.Player.ToList(); 
    	
        /* if not load BasketballClub try this way
        var playerList = new List<Player>();
    	using (var db = new BasketDbContext())
    	{
    		playerList = db.Player.Include(x=>x.BasketballClub).ToList();  
    	}
    	*/
    	
    	PlayerIndex1Model playerVM = new PlayerIndex1Model();
    
    	List<PlayerIndex1Model> playerVMList = playerList.Select(x => new PlayerIndex1Model
    	{
    		PlayerName = x.PlayerName,
    		Id = x.Id,
    		PlayerHeight=x.PlayerHeight,
    		PlayerSurname=x.PlayerSurname,
    		PlayerPosition=x.PlayerPosition,
    		Birthday=x.Birthday,
    		
    		PlayerWeight=x.PlayerWeight,
    		BasketBallClubId = x.BasketballClubId,
    		ClubName = x.BasketBallClub?.ClubName ?? "" //if BasketballClub is not null returns ClubName otherwise ""
    						  
    	}).ToList();
    
    	return View(playerVMList);
    }
