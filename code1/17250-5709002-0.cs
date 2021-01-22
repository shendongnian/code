    List<Order> orders = dataContext.Orders.FetchByIds(
      orderIdChunks,
      list => row => list.Contains(row.OrderId)
    );
    List<Customer> customers = dataContext.Orders.FetchByIds(
      orderIdChunks,
      list => row => list.Contains(row.OrderId),
      row => row.Customer
    );
        public static List<ResultType> FetchByIds<RecordType, ResultType>(
            this IQueryable<RecordType> querySource,
            List<List<int>> IdChunks,
            Func<List<int>, Expression<Func<RecordType, bool>>> filterExpressionGenerator,
            Expression<Func<RecordType, ResultType>> projectionExpression
        ) where RecordType : class
        {
            List<ResultType> result = new List<ResultType>();
            foreach (List<int> chunk in IdChunks)
            {
                Expression<Func<RecordType, bool>> filterExpression =
                    filterExpressionGenerator(chunk);
                IQueryable<ResultType> query = querySource
                    .Where(filterExpression)
                    .Select(projectionExpression);
                List<ResultType> rows = query.ToList();
                result.AddRange(rows);
            }
            return result;
        }
        public static List<RecordType> FetchByIds<RecordType>(
            this IQueryable<RecordType> querySource,
            List<List<int>> IdChunks,
            Func<List<int>, Expression<Func<RecordType, bool>>> filterExpressionGenerator
        ) where RecordType : class
        {
            Expression<Func<RecordType, RecordType>> identity = r => r;
            return FetchByIds(
                querySource,
                IdChunks,
                filterExpressionGenerator,
                identity
                );
        }
