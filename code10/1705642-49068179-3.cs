    public class BasketDbContext : DbContext
    {
    	public BasketDbContext()
    		: base("BasketDb")
    	{
    		
    	}
    		
    	public DbSet<Player> Player { get; set; }
    	public DbSet<BasketBallClub> BasketBallClub { get; set; }
    	
    	
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    
    		modelBuilder.Configurations.Add(new PlayerMap());
    		modelBuilder.Configurations.Add(new BasketBallClubMap());
    	}
    
    }
    
    using System.Data.Entity.ModelConfiguration;
    public class PessoaMap : EntityTypeConfiguration<Player>
    {
    	public PlayerMap()
    	{
    		// Primary Key
    		HasKey(t => t.Id);
    
    		// Properties
    		Property(t => t.PlayerName).HasMaxLength(50); //.HasColumnName("player_name");
    		Property(t => t.PlayerSurname).HasMaxLength(50);
    		Property(t => t.PlayerWeight);
    		//..... configure all columns 
    		
    		//Relationships
    		
    		HasRequired(t => t.BasketBallClub)
                    .WithMany(t => t.Players)
                    .HasForeignKey(d => d.BasketBallClubId)
                    .WillCascadeOnDelete(false);
    	}
    }
    
    using System.Data.Entity.ModelConfiguration;
    public class BasketBallClubMap : EntityTypeConfiguration<BasketBallClub>
    {
    	public BasketBallClubMap()
    	{
    		// Primary Key
    		HasKey(t => t.Id);
    
    		// Properties
    		Property(t => t.Id); //.HasColumnName("id");
    		Property(t => t.ClubName).HasMaxLength(50); //.HasColumnName("club_name");
    	}
    }
     
    // Your Model
    public class PlayerIndex1Model
    {
    	public int Id { get; set; }
    	public string PlayerName { get; set; }
    	public string PlayerSurname { get; set; }
        //... omitted other columns 
    	public int BasketBallClubId { get; set; }
    	public virtual BasketBallClub BasketBallClub { get; set; }
    }
    
    public class BasketBallClub
    {
    	public int Id { get; set; }
    	public string ClubName { get; set; }
    	
    	public virtual IColletion<Player> Players { get;set; } 
    }
