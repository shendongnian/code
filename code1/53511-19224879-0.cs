    public class TableNameConvention
        : IClassConvention, IClassConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IClassInspector> criteria)
        {
            criteria.Expect(x => Check(x));
        }
        private bool Check(IClassInspector x)
        {
            return String.IsNullOrWhiteSpace(x.TableName) || x.TableName.Equals("`{0}`".Args(x.EntityType.Name));
        }
        public void Apply(IClassInstance instance)
        {
            instance.Table("`" + instance.EntityType.Name + "`");
        }
    }
