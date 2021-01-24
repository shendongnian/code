     var _response = await _client.QueryAsync(_request);
     using (DynamoDBContext dbcontext = new DynamoDBContext(_client))
     {
          foreach (var item in _response.Items)
          {
               var doc = Document.FromAttributeMap(item);
               var myModel = dbcontext.FromDocument<Attendence>(doc);
               attendence.Add(myModel);
          }
      }
