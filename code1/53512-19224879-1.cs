    public class ColumnNameConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column("`" + instance.Property.Name + "`");
        }
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(c => Check(c));
        }
        private bool Check(IPropertyInspector inspector)
        {
            //walkaround:
            //this convention causes problems with Components - creates columns like Issue`Id` so we apply it only to entities
            var type = inspector.EntityType;
            if (!(type.IsSubclassOf(typeof (Entity)) || type.IsSubclassOf(typeof (GlossaryEntity))))
            {
                return false;
            }
            return true;
        }
    }
