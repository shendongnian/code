    public partial class ApplicationDBContext
    {
    	private static Dictionary<Type, EntitySetBase> _mappingCache =
    		new Dictionary<Type, EntitySetBase>();
    
    	private string GetTableName(Type type)
    	{
    		EntitySetBase es = GetEntitySet(type);
    
    		return string.Format("[{0}].[{1}]",
    			es.MetadataProperties["Schema"].Value,
    			es.MetadataProperties["Table"].Value);
    	}
    
    	private string GetPrimaryKeyName(Type type)
    	{
    		EntitySetBase es = GetEntitySet(type);
    
    		return es.ElementType.KeyMembers[0].Name;
    	}
    
    	private EntitySetBase GetEntitySet(Type type)
    	{
    		if (!_mappingCache.ContainsKey(type))
    		{
    			ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;
    
    			string typeName = ObjectContext.GetObjectType(type).Name;
    
    			var es = octx.MetadataWorkspace
    							.GetItemCollection(DataSpace.SSpace)
    							.GetItems<EntityContainer>()
    							.SelectMany(c => c.BaseEntitySets
    											.Where(e => e.Name == typeName))
    							.FirstOrDefault();
    
    			if (es == null)
    				throw new ArgumentException("Entity type not found in GetTableName", typeName);
    
    			_mappingCache.Add(type, es);
    		}
    
    		return _mappingCache[type];
    	}
    }
