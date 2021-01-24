    IReadOnlyCollection<Person> PerformQuery(PersonQuery queryId)
    {
         using (var dbContext = new MyDbContext())
         {
              // get the Expression from the dictionary:
              var expression = this.QueryDictionary[queryId];
              // translate to IQueryable:
              var query = dbContext.ToQueryable<Person>(expression);
              // perform the query:
              return query.ToList();
              // because all items are fetched by now, the DbContext may be Disposed
         }
    }
