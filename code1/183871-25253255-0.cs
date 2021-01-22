    public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (Type classType in from t in Assembly.GetAssembly(typeof(DecimalPrecisionAttribute)).GetTypes()
                                       where t.IsClass && t.Namespace == "FA.f1rstval.Data"
                                       select t)
            {
                foreach (var propAttr in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<DecimalPrecisionAttribute>() != null).Select(
                       p => new { prop = p, attr = p.GetCustomAttribute<DecimalPrecisionAttribute>(true) }))
                {
                    ParameterExpression param = ParameterExpression.Parameter(classType, "c");
                    Expression property = Expression.Property(param, propAttr.prop.Name);
                    LambdaExpression lambdaExpression = Expression.Lambda(property, true,
                                                                             new ParameterExpression[] { param });
                    DecimalPropertyConfiguration decimalConfig;
                    int MethodNum;
                    if (propAttr.prop.PropertyType.IsGenericType && propAttr.prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        MethodNum = 7;
                    }
                    else
                    {
                        MethodNum = 6;
                    }
                    //check if complextype
                    if (classType.GetCustomAttribute<ComplexTypeAttribute>() != null)
                    {
                        var complexConfig = modelBuilder.GetType().GetMethod("ComplexType").MakeGenericMethod(classType).Invoke(modelBuilder, null);
                        MethodInfo methodInfo = complexConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[MethodNum];
                        decimalConfig = methodInfo.Invoke(complexConfig, new[] { lambdaExpression }) as DecimalPropertyConfiguration;
                    }
                    else
                    {
                        var entityConfig = modelBuilder.GetType().GetMethod("Entity").MakeGenericMethod(classType).Invoke(modelBuilder, null);
                        MethodInfo methodInfo = entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[MethodNum];
                        decimalConfig = methodInfo.Invoke(entityConfig, new[] { lambdaExpression }) as DecimalPropertyConfiguration;
                    }
                    decimalConfig.HasPrecision(propAttr.attr.Precision, propAttr.attr.Scale);
                }
            }
        }
