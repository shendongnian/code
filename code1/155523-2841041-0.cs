    public class OraclePrimaryKeySequenceConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Sequence(string.Format("Sequence_{0}",
                                                        instance.EntityType.Name));
        }
    }
