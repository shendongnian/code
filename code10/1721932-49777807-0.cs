		public void Add(Object o)
		{
			var contextProperties = this.GetType().GetProperties();
			contextProperties = contextProperties.Where(s => s.PropertyType.IsGenericType && s.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)).ToArray<PropertyInfo>();
			PropertyInfo DbSetToUpdate = contextProperties.Where(s => s.PropertyType.GetGenericArguments()[0] == o.GetType()).FirstOrDefault();
			object DbSetInstance = DbSetToUpdate.GetValue(this, null);
			Type DbSetType = DbSetInstance.GetType();
			MethodInfo DbSetMethod = DbSetType.GetMethod("Add");
			DbSetMethod.Invoke(DbSetInstance, new object[] { o });
		}
