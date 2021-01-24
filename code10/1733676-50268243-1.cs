    TypeSerializerDefinitions definitions = new TypeSerializerDefinitions();
    definitions.Define(new DateCodec());
    
    var cluster = Cluster.Builder()
             .AddContactPoints("localhost")
             .WithTypeSerializers(definitions)
             .Build();
    var session = cluster.Connect();
    var rs = session.Execute("SELECT * FROM test.dt");
    foreach (var row in rs)
    {
        var id = row.GetValue<int>("id");
        var date = row.GetValue<DateTime>("d");
        Console.WriteLine("id=" + id + ", date=" + date);
    }
    
    var pq = session.Prepare("insert into test.dt(id, d) values(?, ?);");
    var bound = pq.Bind(10, new DateTime(2018, 04, 01));
    session.Execute(bound);
