    public static IEnumerable<T> ExecuteQuery<T>(this CloudTable table, TableQuery<T> query) where T : ITableEntity, new()
        {
            List<T> result = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                // Retrieve a segment (up to 1,000 entities).
                TableQuerySegment<T> tableQueryResult = table.ExecuteQuerySegmentedAsync(query, continuationToken).Result;
                result.AddRange(tableQueryResult.Results);
                continuationToken = tableQueryResult.ContinuationToken;
            } while (continuationToken != null);
            return result;
        }
