    public static class MyExtensions
    {
        public static IQueryable<TRow> Where<TRow, TValue>(
            this IQueryable<TRow> rows,
            string columnName, TValue value)
            where TRow : DataRow
        {
            var param = Expression.Parameter(typeof(TRow), "row");
            var fieldMethod = (from method in typeof(DataRowExtensions).GetMethods()
                               where method.Name == "Field"
                               && method.IsGenericMethod
                               let args = method.GetParameters()
                               where args.Length == 2
                               && args[1].ParameterType == typeof(string)
                               select method)
                               .Single()
                               .MakeGenericMethod(typeof(TValue));
            var body = Expression.Equal(
                Expression.Call(null,fieldMethod,
                    param,
                    Expression.Constant(columnName, typeof(string))),
                Expression.Constant(value, typeof(TValue))
            );
            var lambda = Expression.Lambda<Func<TRow, bool>>(body, param);
            return rows.Where(lambda);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataTable tempResults = new DataTable();
            tempResults.Columns.Add("ColumnName");
            tempResults.Rows.Add("foo");
            tempResults.Rows.Add("Column");
            var test = tempResults.AsEnumerable().AsQueryable()
                       .Where("ColumnName", "Column");
            Console.WriteLine(test.Count());
        }
    }
