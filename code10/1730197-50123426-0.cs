    List<SomeClass> result = new List<SomeClass>();
    using (var reader = await command.ExecuteReaderAsync())
    {
        while( reader.Read() )
        {
            result.Add(new SomeClass(dr.GetInt32(0), dr.GetString(1));
        }
    }
    return Ok(result);
