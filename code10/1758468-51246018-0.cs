            public interface IDatabases
            {
                string GetEmployeeFullName();
            }
    
            public interface ISQLDatabase : IDatabases
            {
                int GetEmployeeId();
            }
    
            public class OracleDB : IDatabases
            {
                public string GetEmployeeFullName()
                {
                    return "Name oracle";
                }
            }
    
            public class SqlServerDB : ISQLDatabase
            {
                public string GetEmployeeFullName()
                {
                    return "Name sql server";
                }
    
                public int GetEmployeeId()
                {
                    return 1;
                }
            }
    
            public class RegistrationStaff
            {
                private IDatabases objDatabase;
    
                public RegistrationStaff(IDatabases vobjDataBase)
                {
                    this.objDatabase = vobjDataBase;
    
                    if (this.objDatabase is ISQLDatabase)
                    {
                        Console.WriteLine(((ISQLDatabase)this.objDatabase).GetEmployeeId());
                    }
                }
            }
