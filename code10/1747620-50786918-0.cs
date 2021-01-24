    public  IEnumerable<Place> SelectPlaces()
    {
        string query = @"SELECT p.id, p.PlaceName, t.id, t.tagname
                         FROM Place p INNER JOIN TagPlace tp ON tp.PlaceID = p.Id
                         INNER JOIN tag t ON tp.tagid = this.id";
        var result = default(IEnumerable<Place>);
        Dictionary<int, Place> lookup = new Dictionary<int, Place>();
        using (IDbConnection connection = GetOpenedConnection())
        {
             // Each record is passed to the delegate where p is an instance of
             // Place and t is an instance of Tag
             result = connection.Query<Place, Tag, Place(cmd, (p, t) =>
             {
                  // If the place still doesn't exist, add it to the dictionary
                  if (!lookup.TryGetValue(p.Id, out Place placeFound))
                  {
                       lookup.Add(p.Id, p);
                       placeFound = p;
                  }
                  placeFound.Tags.Add(t);
                  return placeFound;
              }, splitOn: "id");
              // SplitOn is where we tell Dapper how to split the record returned
              // in the two instances required, but here
              // SplitOn is not really needed because it is the default.
          
         }
         return result;
    }
