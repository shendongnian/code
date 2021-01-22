    public class ManufacturerMap : ClassMap<Manufacturer>
    {
        public ManufacturerMap()
        {
            Id(x => x.ID).GeneratedBy.Custom<StringTableHiLoGenerator>(a => a.AddParam("max_lo", Nexus3General.HiLoGeneratorMaxLoSize.ToString()));
            Map(x => x.Name);
        }
    }
    public class StringTableHiLoGenerator : TableHiLoGenerator
    {
        public override object Generate(ISessionImplementor session, object obj)
        {
            return base.Generate(session, obj).ToString();
        }
        public override void Configure(IType type, System.Collections.Generic.IDictionary<string, string> parms, NHibernate.Dialect.Dialect dialect)
        {
            base.Configure(NHibernateUtil.Int32, parms, dialect);
        }
    }
