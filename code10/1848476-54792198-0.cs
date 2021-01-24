    public class TypeToIgnore { }
    
    void Main()
    {
    
    	var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
    	config.AssertConfigurationIsValid(); // won't throw
    }
    
    class Type1
    {
    	public int Prop1 { get; set; }
    	public string Prop2 { get; set; }
    	public bool Prop3 { get; set; }
    }
    
    class Type2
    {
    	public int Prop1 { get; set; }
    	public string Prop2 { get; set; }
    	public TypeToIgnore Prop3 { get; set; }
    	public long Prop4 { get; set; }
    	public double Prop5 { get; set; }
    }
    
    class MappingProfile : Profile
    {
    	public MappingProfile()
    	{
    		ShouldMapProperty = p => p.PropertyType != typeof(bool);
    		CreateMap<Type2, Type1>();
    	}
    }
