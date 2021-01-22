		private void OnModelCreatingSetDecimalPrecisionFromAttribute(DbModelBuilder modelBuilder)
		{
			foreach (var iSetProp in this.GetType().GetTypeProperties(true))
			{
				if (iSetProp.PropertyType.IsGenericType
						&& (iSetProp.PropertyType.GetGenericTypeDefinition() == typeof(IDbSet<>) || iSetProp.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)))
				{
					var entityType = iSetProp.PropertyType.GetGenericArguments()[0];
					foreach (var propAttr in entityType
											.GetProperties(BindingFlags.Public | BindingFlags.Instance)
											.Select(p => new { prop = p, attr = p.GetCustomAttribute<DecimalPrecisionAttribute>(true) })
											.Where(propAttr => propAttr.attr != null))
					{
						var entityTypeConfigMethod = modelBuilder.GetType().GetTypeInfo().DeclaredMethods.First(m => m.Name == "Entity");
						var entityTypeConfig = entityTypeConfigMethod.MakeGenericMethod(entityType).Invoke(modelBuilder, null);
						var param = ParameterExpression.Parameter(entityType, "c");
						var lambdaExpression = Expression.Lambda(Expression.Property(param, propAttr.prop.Name), true, new ParameterExpression[] { param });
						var propertyConfigMethod =
							entityTypeConfig.GetType()
								.GetTypeMethods(true, false)
								.First(m =>
								{
									if (m.Name != "Property")
										return false;
									var methodParams = m.GetParameters();
									return methodParams.Length == 1 && methodParams[0].ParameterType == lambdaExpression.GetType();
								}
								);
						var decimalConfig = propertyConfigMethod.Invoke(entityTypeConfig, new[] { lambdaExpression }) as DecimalPropertyConfiguration;
						decimalConfig.HasPrecision(propAttr.attr.Precision, propAttr.attr.Scale);
					}
				}
			}
		}
		public static IEnumerable<MethodInfo> GetTypeMethods(this Type typeToQuery, bool flattenHierarchy, bool? staticMembers)
		{
			var typeInfo = typeToQuery.GetTypeInfo();
			foreach (var iField in typeInfo.DeclaredMethods.Where(fi => staticMembers == null || fi.IsStatic == staticMembers))
				yield return iField;
			//this bit is just for StaticFields so we pass flag to flattenHierarchy and for the purpose of recursion, restrictStatic = false
			if (flattenHierarchy == true)
			{
				var baseType = typeInfo.BaseType;
				if ((baseType != null) && (baseType != typeof(object)))
				{
					foreach (var iField in baseType.GetTypeMethods(true, staticMembers))
						yield return iField;
				}
			}
		}
