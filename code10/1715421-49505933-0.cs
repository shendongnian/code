    // Sample classes
    public class MenuTable
    {
    	public string MenuProp1 {get;set;}
    }
    
    public class RoleTable
    {
    	public string RoleProp1 {get;set;}
    }
    
    public class Menu
    {
    	public string MenuProp1 {get;set;}
    }
    
    public class Role
    {
    	public string RoleProp1 {get;set;}
    }
    public class Program
    {
    	public static void Main()
    	{
    		// Mapper config
    		Mapper.Initialize(cfg => {});
    		
    		// sample Data
    		var menuTable1 = new MenuTable() {MenuProp1="Menu1"};
    		var menuTable2 = new MenuTable() {MenuProp1="Menu2"};
    		var roleTable1 = new RoleTable() {RoleProp1="Role1"};
    		var roleTable2 = new RoleTable() {RoleProp1="Role2"};
    		
    		// Map by property name
    		var target = Mapper.Map<Menu>(menuTable1);
    		Console.WriteLine("Map by property by name: " + target.MenuProp1);
    		Console.WriteLine();
    		// result: "Map by property by name: Menu1"
    		// Map KeyValuePair
    		var kvpSource = new KeyValuePair<MenuTable, RoleTable>(menuTable1, roleTable1);
    		var kvpTarget = Mapper.Map<KeyValuePair<Menu, Role>>(kvpSource);
    		Console.WriteLine("Map KeyValuePair: " + kvpTarget.Key.MenuProp1 + " - " + kvpTarget.Value.RoleProp1);
    		Console.WriteLine();
		    // result: "Map KeyValuePair: Menu1 - Role1"
    		
    		// Map List
    		var listSource = new List<MenuTable>() {menuTable1, menuTable2};
    		var listTarget = Mapper.Map<List<Menu>>(listSource);
    		foreach(var item in listTarget)
    		{	
    			Console.WriteLine("Map List:" + item.MenuProp1);
    		}	
    		Console.WriteLine();
    		// result:
    		// Map List:Menu1
    		// Map List:Menu2
    		
    		// Combination
    		var combinedSource = new List<KeyValuePair<MenuTable, List<RoleTable>>>()
    		{
    			new KeyValuePair<MenuTable, List<RoleTable>>(menuTable1, new List<RoleTable>(){roleTable1}),
    			new KeyValuePair<MenuTable, List<RoleTable>>(menuTable2, new List<RoleTable>(){roleTable2})
    		};
    		
    		var combinedTarget = Mapper.Map<List<KeyValuePair<Menu, List<Role>>>>(combinedSource);
    		
    		foreach(var item in combinedTarget)
    		{	
    			Console.WriteLine("Combined: " + item.Key.MenuProp1 + " - " + item.Value.First().RoleProp1);
    		}		
		    // result:
		    // Combined: Menu1 - Role1
	    	// Combined: Menu2 - Role2
    	}
    }
