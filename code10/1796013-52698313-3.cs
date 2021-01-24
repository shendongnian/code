    IEnumerable<Account> FetchFilterResultData(...)
    {
         var fetchedData = db.GetFilterResult(...);
         // return emtpy sequence if null returned:
         return fetchedData ?? Enummerable.Empty<Account>();
         // TODO: exception handling needed?
    }
