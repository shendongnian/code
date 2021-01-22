    using System.Data.EntityClient;
    ...
    EntityConnection conn = new EntityConnection(myContext.Connection.ConnectionString);
    conn.Open();
    EntityCommand cmd = conn.CreateCommand();
    cmd.CommandText = @"Select t.MyValue From MyEntities.MyTable As t";
    var queryExpression = cmd.Expression;
    ....
    conn.Close();
