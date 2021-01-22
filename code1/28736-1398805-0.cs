    public partial class MyDataContext
    {
        public IQueryable<MyView> MyView
        {
            get
            {
                var query1 = 
                    from a in TableA
                    let default_ColumnFromB = (string)null
                    select new MyView()
                    {
                        ColumnFromA = a.ColumnFromA,
                        ColumnFromB = default_ColumnFromB,
                        ColumnSharedByAAndB = a.ColumnSharedByAAndB,
                    };
                var query2 = 
                    from a in TableB
                    let default_ColumnFromA = (decimal?)null
                    select new MyView()
                    {
                        ColumnFromA = default_ColumnFromA,
                        ColumnFromB = b.ColumnFromB,
                        ColumnSharedByAAndB = b.ColumnSharedByAAndB,
                    };
                return query1.Union(query2);
            }
        }
    }
    
    public class MyView
    {
        public decimal? ColumnFromA { get; set; }
        public string ColumnFromB { get; set; }
        public int ColumnSharedByAAndB { get; set; }
    }
