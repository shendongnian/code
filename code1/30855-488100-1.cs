    public interface IThing
    {
       ... methods to do the things that Things do
    }
    public class FileThing : IThing
    {
      ... file-based methods
    }
    public class DatabaseThing : IThing
    {
      ... database-based methods
    }
    public static class ThingFactory
    {
         public IThing GetFileThing( string name )
         {
             return new FileThing( name );
         }
         public IThing GetDatabaseThing( string connectionString )
         {
             return new DatabaseThing( connectionString );
         }
    }
