    public class SelectQueryBuilder : QueryBuilder<SelectTableBuilder>
    {
        public override SelectTableBuilder Tables=> new SelectTableBuilder(Query);
    }
    
    public class CrossTabQueryBuilder : QueryBuilder<CrossTabTableBuilder>
    {
        public override CrossTabTableBuilder Tables => new CrossTabTableBuilder(Query);
    }
