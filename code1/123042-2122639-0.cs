    public class DatabaseTypeAttribute : Attribute
    {
        public DatabaseTypeAttribute(Type type)
        {
            Type = type;
        }
        public Type Type { get; private set; }
    }
    
    public enum DatabaseField : int
    {
        [DatabaseType(typeof(long))]
        NumID1 = 1,
        [DatabaseType(typeof(int))]
        NumID2 = 2,
        [DatabaseType(typeof(short))]
        NumID3 = 3,
        NumID4 = 4,
    };
    
    public static class DatabaseFieldHelper
    {
        public static Type GetDatabaseType(this DatabaseField field)
        {
            var attributes = (DatabaseTypeAttribute[])typeof(DatabaseField).GetField(Enum.GetName(typeof(DatabaseField), field))
                .GetCustomAttributes(typeof(DatabaseTypeAttribute), false);
            if (attributes.Length == 0)
                return typeof(int); //returns default type
            return attributes[0].Type;
    
        }
    }
    
    //prints: NumID1 database type: System.Int64
    Console.WriteLine("NumID1 database type: {0}", DatabaseField.NumID1.GetDatabaseType());
    
    //prints: NumID2 database type: System.Int32
    Console.WriteLine("NumID2 database type: {0}", DatabaseField.NumID2.GetDatabaseType());
    
    //prints: NumID3 database type: System.Int16
    Console.WriteLine("NumID3 database type: {0}", DatabaseField.NumID3.GetDatabaseType());
    
    //prints: NumID4 database type: System.Int32
    Console.WriteLine("NumID4 database type: {0}", DatabaseField.NumID4.GetDatabaseType());
