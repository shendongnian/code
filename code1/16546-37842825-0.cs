    My Solution:
    public static class DbHelper
    {
        public static string ToString(this DbParameterCollection parameters, string sqlQuery)
        {
            return parameters.Cast<DbParameter>().Aggregate(sqlQuery, (current, p) => current.Replace(p.ParameterName, p.Value.ToString()));
        }
    }
