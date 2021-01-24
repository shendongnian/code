    string defaultConString = 
    @"server=.\SQLExpress;Database=SampleDb;Trusted_Connection=yes;";
    
    void Main()
    {
    	CreateData();
    	// check db state
    	ListData();
    	// Done with sample database. Delete.
    	// new SampleContext(defaultConString).Database.Delete();
    }
    
    private void CreateData()
    {
    	var db = new SampleContext(defaultConString);
    	if (db.Database.CreateIfNotExists())
    	{
    
    		// Create some types
    		var tHW = new Type { Name = "Hardware" };
    		var tSW = new Type { Name = "Software" };
    		var tFW = new Type { Name = "Firmware" };
    		db.Types.AddRange(new Type[] {tHW,tSW,tFW});
    		db.SaveChanges();
    
    		// create some Attributes using types above
    		var a1 = new Attribute
    		{
    			Name = "Macbook Pro",
    			Type = tHW,
    			AttrProperties = new List<AttrProperty> {
    				new AttrProperty{ Description=@"15"" retina" },
    				new AttrProperty{ Description=@"i9-8950HK" },
    				new AttrProperty{ Description=@"32Gb DDR4 RAM" },
    				new AttrProperty{ Description=@"512Gb SSD" },
    				new AttrProperty{ Description=@"AMD Radeon Pro 555" },
    				new AttrProperty{ Description=@"OSX Mojave 10.14" },
    				}
    		};
    		var a2 = new Attribute
    		{
    			Name = "iMac",
    			Type = tHW,
    			AttrProperties = new List<AttrProperty> {
    				new AttrProperty{ Description=@"27"" retina 5K" },
    				new AttrProperty{ Description=@"i5 3.4Ghz" },
    				new AttrProperty{ Description=@"40Gb DDR4 RAM" },
    				new AttrProperty{ Description=@"1Tb Fusion" },
    				new AttrProperty{ Description=@"AMD Radeon Pro 570" },
    				new AttrProperty{ Description=@"OSX Mojave 10.14" },
    				}
    		};
    		var a3 = new Attribute
    		{
    			Name = "PC",
    			Type = tHW,
    			AttrProperties = new List<AttrProperty> {
    				new AttrProperty{ Description=@"AMD Ryzen Threadripper 1950x" },
    				new AttrProperty{ Description=@"64Gb RAM" },
    				new AttrProperty{ Description=@"1 Tb 7400 RPM" },
    				new AttrProperty{ Description=@"512Gb M2 mSATA" },
    				new AttrProperty{ Description=@"AMD Radeon Pro 570" },
    				new AttrProperty{ Description=@"Linux-Debian 9.5" },
    				}
    		};
    
    		var a4 = new Attribute
    		{
    			Name = "Database",
    			Type = tSW,
    			AttrProperties = new List<AttrProperty> {
    				new AttrProperty{ Description=@"postgreSQL" },
    				new AttrProperty{ Description=@"11 (beta)" },
    				}
    		};
    
    		var a5 = new Attribute
    		{
    			Name = "SomeROM",
    			Type = tFW,
    			AttrProperties = new List<AttrProperty> {
    				new AttrProperty{ Description=@"SomeROM update" },
    				new AttrProperty{ Description=@"Some version" },
    				}
    		};
    
    		db.Attributes.AddRange(new Attribute[] {a1,a2,a3,a4,a5});
    
    		// Some projects using those
    
    		var p1 = new Project
    		{
    			Name = "P1",
    			StartDate = new DateTime(2018, 1, 1),
    			Attributes = new List<Attribute>() { a1, a2, a4 }
    		};
    		var p2 = new Project
    		{
    			Name = "P2",
    			StartDate = new DateTime(2018, 1, 1),
    			Attributes = new List<Attribute>() { a1, a3, a5 }
    		};
    		var p3 = new Project
    		{
    			Name = "P3",
    			StartDate = new DateTime(2018, 1, 1),
    			Attributes = new List<Attribute>() { a2, a3, a4, a5 }
    		};
    
    		db.Projects.AddRange(new Project[] { p1,p2,p3 });
    		db.SaveChanges();
    	}
    }
    
    private void ListData()
    {
    	var db = new SampleContext(defaultConString);
    //	db.Database.Log =Console.Write;
    	foreach (var p in db.Projects.Include("Attributes").ToList())
    	{
    		Console.WriteLine($"Project {p.Name}, started on {p.StartDate}. Has Attributes:");
    		foreach (var a in p.Attributes)
    		{
    			Console.WriteLine($"\t{a.Name} [{a.Type.Name}] ({string.Join(",",a.AttrProperties.Select(ap => ap.Description))})");
    		}
    	}
    }
    
    public class Type
    {
    	public int TypeId { get; set; }
    	public string Name { get; set; }
    
    	public virtual List<Attribute> Attributes { get; set; }
    	public Type()
    	{
    		Attributes = new List<Attribute>();
    	}
    }
    
    public class Attribute
    {
    	public int AttributeId { get; set; }
    	public string Name { get; set; }
    	public int TypeId { get; set; }
    	public virtual Type Type { get; set; }
    	public virtual List<Project> Projects { get; set; }
    	public virtual List<AttrProperty> AttrProperties { get; set; }
    	public Attribute()
    	{
    		Projects = new List<Project>();
    	}
    }
    
    public class AttrProperty
    { 
    	public int AttrPropertyId { get; set; }
    	public string Description { get; set; }
    	public virtual Attribute Attribute {get;set;}
    }
    
    public class Project
    {
    	public int ProjectId { get; set; }
    	public string Name { get; set; }
    	public DateTime StartDate { get; set; }
    	public virtual List<Attribute> Attributes {get;set;}
    	
        public Project()
    	{
    		Attributes = new List<Attribute>();
    	}
    }
    
    
    public class SampleContext : DbContext
    {
    	public SampleContext(string connectionString) : base(connectionString) { }
    	public DbSet<Type> Types { get; set; }
    	public DbSet<Attribute> Attributes { get; set; }
    	public DbSet<Project> Projects { get; set; }
    }
