    public partial class MyDataContext : System.Data.Linq.DataContext
    {
        partial void InsertTestTable(TestTable instance)
        {
            using (var cmd = Connection.CreateCommand()) 
            {
                cmd.CommandText = "SELECT NEXT VALUE FOR [dbo].[seq_PK_TestTable] as NextId";
                cmd.Transaction = Transaction;
                int nextId = (int) cmd.ExecuteScalar();
                instance.id = nextId;
                ExecuteDynamicInsert(instance);
            }         
        }
    }
