    public sealed class SingletonDB
    {
       private static readonly SingletonDB instance = new SingletonDB();
       private readonly SqlConnection con =new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
       // Explicit static constructor to tell C# compiler
       // not to mark type as beforefieldinit
       static SingletonDB()
       {
       }
       private SingletonDB()
       {
       }
       public static SingletonDB Instance
       {
           get
           {
              return instance;
           }
       }
       public SqlConnection GetDBConnection()
       {
           return con;
       }
