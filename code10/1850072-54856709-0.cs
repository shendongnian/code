    void Main()
    {
    	IConfigurationProvider conf = new MapperConfiguration(exp => exp.CreateMap<Src, Dest>());
    	IMapper mapper = new Mapper(conf);
    	
    	var src = new Src(){
    	   Id =1,
    	   Name= "John Doe"
    	};
    	
    	var result = mapper.Map<Dest>(src, options => options.AfterMap((s, d) => ((Dest) d).Name = null));
    	result.Dump();
    	
    }
    
    public class Src 
    {
    	public int Id {get; set;}
    	public string Name {get; set;}
    }
    
    public class Dest
    {
    	public int Id {get; set;}
    	public string Name {get; set;}
    }
