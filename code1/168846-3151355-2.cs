    public class FooAuditMap : SubclassMap<FooAudit>
    {
        public FooAuditMap()
        {
            Table("FooAudit");
            CompositeId()
                .KeyProperty(x => x.DateModified, c => c.ColumnName("AUDIT_DATE"));
                .KeyProperty(x => x.Id, c => c.ColumnName("FOO_ID"));
            Map(x => x.SomeValue).Column("SOME_VALUE");
        }
    }
