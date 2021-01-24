    internal class ProjectEnvironment
    {
       public string Name {get; set;}
       public List<SQLServer> Servers {get; set;}
    }
    
    internal class SQLServer
    {
       public string Name {get; set;}
       public string HostName {get; set;}
       public int Port {get; set;}
       public List<Database> Databases {get; set;}
    }
    
    internal class Database
    {
       public string Name {get; set;}
       public List<string> Tables {get; set;}
    }
