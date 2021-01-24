    public class YourCustomResolver
    	: IMemberValueResolver<object, object, Communication, bool>
    {
    	private Communication _communication;
    
    	public YourCustomResolver(
    		Communication communication)
    	{
    	}
    
    	public bool Resolve(
    		object source, 
    		object destination,
    		Communication sourceMember, 
    		bool destMember, 
    		ResolutionContext context)
    	{
    		return _communication == sourceMember;
    	}
    }
