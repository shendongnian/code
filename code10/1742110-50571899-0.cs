    using AutoMapper;
    using AutoMapper.Configuration.Conventions;
    using System.Reflection;
    
    class CustomMapMember : IChildMemberConfiguration
    {
    	Dictionary<TypePair, PropertyInfo> map = new Dictionary<TypePair, PropertyInfo>();
    
    	public CustomMapMember Add(Type destType, Type sourceType, string sourcePropertyName)
    	{
    		map.Add(new TypePair(sourceType, destType), sourceType.GetProperty(sourcePropertyName));
    		return this;
    	}
    
    	public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers, IMemberConfiguration parent)
    	{
    		if (map.TryGetValue(new TypePair(sourceType.Type, destType), out var property))
    		{
    			resolvers.AddLast(property);
    			var memberType = options.CreateTypeDetails(property.PropertyType);
    			if (parent.MapDestinationPropertyToSource(options, memberType, destType, destMemberType, nameToSearch, resolvers))
    				return true;
    			resolvers.RemoveLast();
    		}
    		return false;
    	}
    }
