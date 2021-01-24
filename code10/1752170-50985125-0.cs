    public class XmlElementAttributeResolver : IMemberValueResolver<object, object, object, object>
    {
    	public object Resolve(object source, object destination, object sourceMember, object destMember, ResolutionContext context)
    	{
    		var sourceMemberType = sourceMember.GetType();
    		var destinationNamespace = destination.GetType().Namespace;
    		var destinationMemberType = destination.GetType().Assembly.GetTypes()
    			.FirstOrDefault(t => t.Name == sourceMemberType.Name && t.Namespace == destinationNamespace);
    
    		return destinationMemberType == null
    			? null
    			: context.Mapper.Map(sourceMember, sourceMemberType, destinationMemberType);
    	}
    }
