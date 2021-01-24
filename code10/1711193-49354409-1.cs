     var results = new List<MyClass>();
     while(query.HasMoreResults)
     {
         results.AddRange(await query.ExecuteNextAsync<MyClass>());
     }
     return results.FirstOrDefault(x => x.MyProp== propValue.ToLower());
