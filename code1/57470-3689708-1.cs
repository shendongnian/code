    public class TimestampTypeConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Type == typeof (DateTime));
        }
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType("timestamp");
        }
    }
