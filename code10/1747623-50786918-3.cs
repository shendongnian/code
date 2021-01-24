    public  IEnumerable<Place> SelectPlaces()
    {
        string query = @"SELECT p.id, p.PlaceName, t.id, t.tagname
                         FROM Place p INNER JOIN TagPlace tp ON tp.PlaceId = p.Id
                         INNER JOIN Tag t ON tp.TagId = t.Id";
        var result = default(IEnumerable<Place>);
        Dictionary<int, Place> lookup = new Dictionary<int, Place>();
        using (IDbConnection connection = GetOpenedConnection())
        {
             // Each record is passed to the delegate where p is an instance of
             // Place and t is an instance of Tag, delegate should return the Place instance.
             result = connection.Query<Place, Tag, Place(cmd, (p, t) =>
             {
                  // Check if we have already stored the Place in the dictionary
                  if (!lookup.TryGetValue(p.Id, out Place placeFound))
                  {
                       // The dictionary doesnt have that Place 
                       // Add it to the dictionary and 
                       // set the variable where we will add the Tag
                       lookup.Add(p.Id, p);
                       placeFound = p;
                       // Probably it is better to initialize the IEnumerable
                       // directly in the class 
                       placeFound.Tags = new List<Tag>();
                  }
                  // Add the tag to the current Place.
                  placeFound.Tags.Add(t);
                  return placeFound;
              }, splitOn: "id");
              // SplitOn is where we tell Dapper how to split the record returned
              // in the two instances required, but here SplitOn 
              // is not really needed because "Id" is the default.
          
         }
         return result;
    }
