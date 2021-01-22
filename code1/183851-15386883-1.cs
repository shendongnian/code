    foreach (Type classType in from t in Assembly.GetAssembly(typeof(DecimalPrecitionAttribute)).GetTypes()
                                       where t.IsClass && t.Namespace == "YOURMODELNAMESPACE"
                                       select t)
            {
                foreach (var propAttr in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<DecimalPrecitionAttribute>() != null).Select(
                    p => new { prop = p, attr = p.GetCustomAttribute<DecimalPrecitionAttribute>(true) }))
                {
                    var entityConfig = modelBuilder.GetType().GetMethod("Entity").MakeGenericMethod(classType).Invoke(modelBuilder, null);
                    ParameterExpression param = ParameterExpression.Parameter(classType, "c");
                    Expression property = Expression.Property(param, propAttr.prop.Name);
                    LambdaExpression lambdaExpression = Expression.Lambda(property, true,
                                                                          new ParameterExpression[]
                                                                              {param});
                    DecimalPropertyConfiguration decimalConfig;
                    if (propAttr.prop.PropertyType.IsGenericType && propAttr.prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        MethodInfo methodInfo = entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[7];
                        DecimalConfig = methodInfo.Invoke(entityConfig, new[] { lambdaExpression }) as DecimalPropertyConfiguration;
                    }
                    else
                    {
                        MethodInfo methodInfo = entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[6];
                        DecimalConfig = methodInfo.Invoke(entityConfig, new[] { lambdaExpression }) as DecimalPropertyConfiguration;
                    }
                    decimalConfig.HasPrecision(propAttr.attr.Precition, propAttr.attr.Scale);
                }
            }
