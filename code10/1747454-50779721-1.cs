    public class Foo : TheClassThatDefinesLoad
    {
        public int TotalLoads { get; private set; }
        protected override V Load(DbDataReader dr)
        {
            var result = base.Load(dr);
            TotalLoads += 1;
            return result;
        }
    }
