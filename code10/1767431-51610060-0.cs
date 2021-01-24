             StringBuilder query = new StringBuilder("SELECT * From TheCollection WHERE ");
            if (idsToCheck.Count() > 0)
                foreach (string idGuid in idsToCheck)
                {
                    query.Append($" CONTAINS(TheCollection.id, '{idGuid}') OR ");
                }
            string builtQuery = query.ToString();
            builtQuery = builtQuery.Substring(0, builtQuery.Length - 4);
            IQueryable<ResultObject> Query = client.CreateDocumentQuery<ResultObject>(
                   collectionUri, queryOptions);
            return Query.ToList();
