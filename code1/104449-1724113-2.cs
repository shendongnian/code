    public Type ClosestAncestor<IParent, Class>()
    {
        return ClosestAncestor<IParent>(typeof(Class));
    }
    
    public Type ClosestAncestor<IParent>(Type typeOfClass)
    {
        var baseType = typeOfClass.BaseType;
        if(typeOfClass.GetInterfaces().Contains(typeof(IParent)) &&
            ! baseType.GetInterfaces().Contains(typeof(IParent)))
        {
            return typeOfClass;
        }
    
        return ClosestAncestor<IParent>(baseType);
    }
