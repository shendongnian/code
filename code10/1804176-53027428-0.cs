    <#@ import namespace="System" #>
    <#+
    public string[] GetEntities()
    {
        // TODO: implement logic to get entitities
    	return new string[] { "Entity01", "Entity02", "Entity03" };
    }
    public class FieldDefinition
    {
    	public string Name { get; set;}
    	public Type Type { get; set; }
    }
    public FieldDefinition[] GetEntityFields(string entityName)
    {
        // TODO: Implement retrieval of Entity fields
    	return new FieldDefinition[] 
    	{ 
    		new FieldDefinition() { Name = "Id", Type = typeof(int) },
    		new FieldDefinition() { Name = "Name", Type = typeof(string) }
    	};
    }
    #>
