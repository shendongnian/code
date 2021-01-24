    using AutoMapper;
    using AutoMapper.Configuration.Conventions;
    using System.Reflection;
    
    class CustomMapMember : IChildMemberConfiguration
    {
    	Dictionary<TypePair, List<PropertyInfo>> map = new Dictionary<TypePair, List<PropertyInfo>>();
    
    	public CustomMapMember Add(Type destType, Type sourceType, string sourcePropertyName)
    	{
    		var key = new TypePair(sourceType, destType);
    		if (!map.TryGetValue(key, out var properties))
    			map.Add(key, properties = new List<PropertyInfo>());
    		properties.Add(sourceType.GetProperty(sourcePropertyName));
    		return this;
    	}
    
    	public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers, IMemberConfiguration parent)
    	{
    		if (map.TryGetValue(new TypePair(sourceType.Type, destType), out var properties))
    		{ 
    			foreach (var property in properties)
    			{
    				resolvers.AddLast(property);
    				var memberType = options.CreateTypeDetails(property.PropertyType);
    				if (parent.MapDestinationPropertyToSource(options, memberType, destType, destMemberType, nameToSearch, resolvers))
    					return true;
    				resolvers.RemoveLast();
    			}
    		}
    		return false;
    	}
    }
