    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(instance.Property.Name.ChangeCamelCaseToUnderscore());
        }
    }
