    public class Mock
    {
        public int Id { get; set; }
        public int ForeignId { get; set; }
        public decimal Total { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Mock>()
            {
                new Mock{
                    Id  = 1,
                    ForeignId = 1,
                    Total = 100,
                },
            };
            var query = list.AsQueryable();
            // t
            var parameter = Expression.Parameter(typeof(Mock), "t");
            // t.Total
            var propertyExpression = Expression.PropertyOrField(parameter, "Total");
            // 100.00M
            var constant = Expression.Constant(100M, typeof(decimal));
            // t.Total == 100.00M 
            var equalExpression = Expression.Equal(propertyExpression, constant);
            
            // t => t.Total == 100.00M
            var lambda = Expression.Lambda(equalExpression, parameter);
            // calls where.
            var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { query.ElementType }, query.Expression, lambda);
            // add where to query.
            query = query.Provider.CreateQuery(whereExpression) as IQueryable<Mock>;
            Console.ReadKey();
        }
    }
