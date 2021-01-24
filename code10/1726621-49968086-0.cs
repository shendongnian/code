    public void Foo(params Type[] types)
    {  
         EnsureInheritedFrom<BaseClass>(types);
         // ...rest of stuff
    }
    private void EnsureInheritedFrom<TBaseType>(IEnumerable<Type> types)
    {
         var targetType = typeof(TBaseType);
         foreach(Type type in types)
         {
             if(!type.IsSubclassOf(targetType))
             {
                 throw new ArgumentException(nameof(types), "Type {type.Name} is not supported!");
             }
         }   
    }
