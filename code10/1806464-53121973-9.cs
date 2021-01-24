	public class DataRepositoryFactory
	{
		Type baseType = typeof(IDataRepository);
		IDictionary<string, Type> typeMap = new Dictionary<string, Type>() { 
			{"File", typeof(FileRepository) } 
			,{"Db", typeof(DatabaseRepository) } 
		}
		public void RegisterType(string typeName, Type type) 
		{
			if (!baseType.IsAssignableFrom(type)) throw new ArgumentException(nameof(type));
			typeMap.Add(typeName, type);	
		}
	
		public IDataRepository GetDataRepository(string typeName)
		{
			return (IDataRepository)Activator.CreateInstance(typeMap[typeName]);
 		}
	}
