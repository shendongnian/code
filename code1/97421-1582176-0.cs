    SqlDataReader dr = dataCommand.ExecuteReader();
    List<Entity> _list = new List<Entity>();
    while(dr.Read())
    { 
       string column1 = dr.GetString(0);
       ...
       string column5 = dr.GetString(4);
       Entity newEntity = new Entity(column1, ......., column5);
       _list.Add(newEntity);
    }
