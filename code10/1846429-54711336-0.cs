    public class SelectedPropertiesContractResolver<T> : CamelCasePropertyNamesContractResolver {
        ...
        public override JsonContract ResolveContract(Type type)
        {
		    return CreateContract(type);
	    }
    }
