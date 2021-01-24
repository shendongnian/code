    public interface IBaseProperties
    {
    	int Id { get; set; }
    	string Name { get; set; }
    }
    
    public class MyTable : IBaseProperties
    {
    	// Add these with either T4 templates or create partial class for each of these entities
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    private IEnumerable<IBaseProperties> GetDbSetByTableName(string tableName)
    {
    	System.Reflection.PropertyInfo[] properties = typeof(ClearGUIEntities).GetProperties();
    	var prop = properties.FirstOrDefault(p => p.Name == tableName + "s");
    
    	using (var db = new ClearGUIEntities())
    	{
    		var dbset = prop?.GetValue(db);
    
    		return new List<IBaseProperties>(dbset as IEnumerable<IBaseProperties>);
    	}
    }
    
    // ...
    // Using it
    // ...
    
    var dynamicdbset = GetDbSetByTableName("MyTable");
    
    int id = dynamicdbset.FirstOrDefault().Id;
