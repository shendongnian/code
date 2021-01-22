    protected override Dictionary<Type, Type> DefineBLLs()
    {
       string bllsAssembly = ConfigurationManager.AppSettings["BLLsAssembly"];
    
       Type[] types = LoadAssembly(bllsAssembly);
    
       Dictionary<Type, Type> bllsTypes = new Dictionary<Type, Type>();
    
       foreach (Type bllType in types)
       {
         if (bllType.IsSubclassOf(typeof(BLL<>)))
         {
            Type baseType = bllType.BaseType;
            Type businessObjectType = baseType.GetGenericArguments()[0];
            bllsTypes.Add(businessObjectType, bllType);
         }
       }
    
       return bllsTypes;
    }
