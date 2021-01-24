    using SqlKata;
    using SqlKata.Execution;
    using System.Collections.Generic;
    using System.Linq;
    // ...
    public static class QueryFactoryExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetAll<T>(this QueryFactory db, params Query[] queries)
        {
            return queries.Select(q =>
            {
                return SqlKata.Execution.QueryFactoryExtensions.Get<T>(db, q);
            });
        }
        public static IEnumerable<IEnumerable<dynamic>> GetAll(this QueryFactory db, params Query[] queries)
        {
            return GetAll<dynamic>(db, queries);
        }
    }
