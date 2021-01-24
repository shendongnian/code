    public static class EntityExtensions
    {
        private static readonly string expressionCannotBeNullMessage = "The expression cannot be null.";
        private static readonly string invalidExpressionMessage = "Invalid expression.";
        public static DataTable ConvertToDataTable<T>(this T instance, Expression<Func<T, object>> proprtiesToSkip = null, Expression<Func<T, object>> proprtiesToRename = null) where T : EntityBase
        {
            string columnName = "";
            string orgPropName;
            int counter = 0;
            Dictionary<string, string> renameProperties = null;
            MemberInfo newName = null;
            NewExpression expression = null;
            List<string> skipProps = null;
        try
        {
            if (proprtiesToSkip != null )
            {
                if (proprtiesToSkip.Body is NewExpression)
                {
                    skipProps = new List<string>();
                    expression = (proprtiesToSkip.Body as NewExpression);
                    foreach (var cExpression in expression.Arguments)
                    {
                        skipProps.Add(GetMemberName(cExpression));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid expression supplied in proprtiesToSkip while converting class to datatable");
                }
            }
            if (proprtiesToRename != null)
            {
                if (proprtiesToRename.Body is NewExpression)
                {
                    renameProperties = new Dictionary<string, string>();
                    expression = (proprtiesToRename.Body as NewExpression);
                    foreach (var cExpression in expression.Arguments)
                    {
                        newName = expression.Members[counter];
                        orgPropName = GetMemberName(cExpression);
                        renameProperties.Add(orgPropName, newName.Name);
                        counter++;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid expression supplied in proprtiesToRename while converting class to datatable");
                }
            }
            var properties = instance.GetType().GetProperties().Where(o =>
            {
                return (skipProps != null && !skipProps.Contains(o.Name, StringComparer.OrdinalIgnoreCase) &&
                        (o.PropertyType != typeof(System.Data.DataTable) && o.PropertyType != typeof(System.Data.DataSet)));
            }).ToArray();
                
            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                columnName = "";
                if (renameProperties != null && renameProperties.ContainsKey(info.Name))
                {
                    columnName = renameProperties[info.Name];
                }
                if (string.IsNullOrEmpty(columnName))
                {
                    columnName = info.Name;
                }
                dataTable.Columns.Add(new DataColumn(columnName, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(instance);
            }
            dataTable.Rows.Add(values);
            return dataTable;
        }
        finally
        {
            renameProperties = null;
            newName = null;
            expression = null;
            skipProps = null;
        }
    }        
    private static string GetMemberName(Expression expression)
    {
        if (expression == null)
        {
            throw new ArgumentException(expressionCannotBeNullMessage);
        }
            
        if (expression is MemberExpression)
        {
            // Reference type property or field
            var memberExpression = (MemberExpression)expression;
            return memberExpression.Member.Name;
        }
        throw new ArgumentException(invalidExpressionMessage);
    }
    }
