     public class Connections: List<Connection>
        {       public new void Add(Connection connection)
            {
                connection.ApplicationName = ApplicationName;
                base.Add(connection);
            }
        }
