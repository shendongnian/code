    const string personQuery = "INSERT INTO Person(X, Y, Width, Height, Confidence) " +
                               "VALUES (@positionX, @positionY, @width, @height, @confidence)";
    // Define a long lived connection and command. Both are Disposable.
    using (var connection = new SqlConnection(myConnectionString))
    using (var personCmd = new SqlCommand(personQuery, connection))
    {
        // Open the connection just the once
        connection.Open();
        // Define the command parameters without assigning them yet
        // Check the data types against your Sql schema ...
        personCmd.Parameters.Add("@positionX", SqlDbType.Int);
        personCmd.Parameters.AddWithValue("@positionY", SqlDbType.Int);
        ... etc other parameters
        // Filter the objects before you loop them. 
        // Better would be .Where(i => i is Person) if you have subclasses
        foreach (var objectItem in items.Where(i => i.Type == "person")) 
        {
            personCmd["@positionX"].Value = objectItem.X;
            personCmd["@positionY"].Value = objectItem.Y;
            ... assign other params
            personCmd.ExecuteNonQuery();
        }
    } // personCmd and connection will be automatically closed 
