    using (var reader = cmd.ExecuteReader())
    {
        var result = new List<Foo>();
        while (reader.Read())
        {
            var foo = new Foo 
            {
                Prop1 = reader.GetInt32(0),
                Prop2 = reader.GetString(1),
            }
            result.Add(foo);
        }
    }
