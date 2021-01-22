        private static Expression BuildLambdaExpression(Type GenericArgument, string FieldName, string FieldValue)
        {
            LambdaExpression lambda = null;
            
            Expression Criteria = null;
            Random r = new Random();
            ParameterExpression predParam = Expression.Parameter(GenericArgument, r.Next().ToString());
            if (GenericArgument.GetProperty(FieldName).PropertyType == typeof(string))
            {
                Expression left = Expression.PropertyOrField(predParam, FieldName);
                Expression LefttoUpper = Expression.Call(left, "ToUpper", null, null);
                //Type du champ recherché
                Type propType = GenericArgument.GetProperty(FieldName).PropertyType;
                Expression right = Expression.Constant(FieldValue, propType);
                Expression RighttoUpper = Expression.Call(right, "ToUpper", null, null);
                Criteria = Expression.Equal(LefttoUpper, RighttoUpper);
            }
            else
            {
                Expression left = Expression.PropertyOrField(predParam, FieldName);
                Type propType = GenericArgument.GetProperty(FieldName).PropertyType;
                Expression right = Expression.Constant(Convert.ChangeType(FieldValue, propType), propType);
                Criteria = Expression.Equal(left, right);
            }
            lambda = Expression.Lambda(Criteria, predParam);
            return lambda;
        }
