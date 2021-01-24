    public class MainProfile : AutoMapper.Profile
    {
    	//[Dependency]
    	//internal AttributeMapper AttributeMapper { get; set; } <--This is not resolved from UnityContainer
    
    	public MainProfile()
    	{
    		CreateMap ...
    		CreateMap<SourceType, DestinationType>()
    			.ForMember(d => d.Item, o => o.ResolveUsing<XmlElementAttributeResolver, object>(s => s.Item));
    	}
    }
