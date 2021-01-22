    // Desired call syntax:
    nameTextBox.Bind(t => t.Text, aBindingSource, (Customer c) => c.FirstName);
    // Binds the Text property on nameTextBox to the FirstName property
    // of the current Customer in aBindingSource, no string literals required.
    
    // Implementation.
    
    public static class ControlExtensions
    {
        public static Binding Bind<TControl, TDataSourceItem>
            (this TControl control, 
             Expression<Func<TControl, object>> controlProperty, 
             object dataSource, 
             Expression<Func<TDataSourceItem, object>> dataSourceProperty)
             where TControl: Control
        {
            return control.DataBindings.Add
                 (PropertyName.For(controlProperty), 
                  dataSource, 
                  PropertyName.For(dataSourceProperty));
        }
    }
    
    public static class PropertyName
    {
        public static string For<T>(Expression<Func<T, object>> property)
        {
            var member = property.Body as MemberExpression;
            if (null == member)
            {
                var unary = property.Body as UnaryExpression;
                if (null != unary) member = unary.Operand as MemberExpression;
            }
            return null != member ? member.Member.Name : string.Empty;
        }
    }
