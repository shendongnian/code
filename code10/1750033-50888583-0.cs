    public abstract class QueryBuilder<T> where T : TableBuilder
    { 
        public Query Query {get;}
        public abstract T Tables { get; }
    }
