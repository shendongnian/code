    public Task<BulkWriteResult<T>> SaveCollection(List<T> items)
    {
      var records = new List<ReplaceOneModel<T>>();
      var processes = new List<Task<ReplaceOneResult>>();
    
      items.ForEach(contract =>
      {
        var record = new ReplaceOneModel<T>(Builders<T>
          .Filter
          .Where(o => o.Id == contract.Id), contract)
        {
          IsUpsert = true
        };
    
        records.Add(record);
      });
    
      return Collection.BulkWriteAsync(records);
    }
