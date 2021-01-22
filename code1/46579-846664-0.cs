    public class Entity {
    	public int IntProp { get; set; }
    	public string StringProp { get; set; }
    }
    
    var e1 = new Entity { IntProp = 2 };
    var e2 = new Entity { StringProp = "hello" };
    var client = new DatabaseClient("you@gmail.com", "password");
    const string dbName = "IntegrationTests";
    Console.WriteLine("Opening or creating database");
    db = client.GetDatabase(dbName) ?? client.CreateDatabase(dbName); // databases are spreadsheets
    const string tableName = "IntegrationTests";
    Console.WriteLine("Opening or creating table");
    table = db.GetTable<Entity>(tableName) ?? db.CreateTable<Entity>(tableName); // tables are worksheets
    table.DeleteAll();
    table.Add(e1);
    table.Add(e2);
    var r1 = table.Get(1);
