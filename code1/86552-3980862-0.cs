    namespace Entities
    {
        public abstract class Node
        {
            public virtual int Id { get; set; }
            public virtual GroupNode Parent { get; set; }
        }
        public class ItemNode : Node
        {
        }
    
        public class GroupNode : Node
        {
            public virtual IList<GroupNode> Groups { get; set; }
            public virtual IList<ItemNode> Items { get; set; }
        }
    }
    
    class Program
    {
        static void Main()
        {
            if (File.Exists("data.db3"))
            {
                File.Delete("data.db3");
            }
    
            using (var factory = CreateSessionFactory())
            {
                using (var connection = factory.OpenSession().Connection)
                {
                    ExecuteQuery("create table GroupNode(Id integer primary key, Parent_Id integer)", connection);
                    ExecuteQuery("create table ItemNode(Id integer primary key, Parent_Id integer)", connection);
    
                    ExecuteQuery("insert into GroupNode(Id, Parent_Id) values (1, null)", connection);
                    ExecuteQuery("insert into GroupNode(Id, Parent_Id) values (2, 1)", connection);
                    ExecuteQuery("insert into GroupNode(Id, Parent_Id) values (3, 1)", connection);
    
                    ExecuteQuery("insert into ItemNode(Id, Parent_Id) values (1, 1)", connection);
                    ExecuteQuery("insert into ItemNode(Id, Parent_Id) values (2, 1)", connection);
                }
    
                using (var session = factory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    var node = session.Get<GroupNode>(1);
                    tx.Commit();
                }
            }
        }
    
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.UsingFile("data.db3").ShowSql()
                )
                .Mappings(
                    m => m.AutoMappings.Add(
                        AutoMap
                            .AssemblyOf<Program>()
                            .Where(t => t.Namespace == "Entities")
                    )
                ).BuildSessionFactory();
        }
    
        static void ExecuteQuery(string sql, IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
