        public IQueryable<T> IncludeAllNavigationProperties<T>(IQueryable<T> queryable)
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");
            ObjectContext objectContext = ((IObjectContextAdapter)Context).ObjectContext;
            var metadataWorkspace = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace();
            EntitySetMapping[] entitySetMappingCollection = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings.ToArray();
            var entitySetMappings = entitySetMappingCollection.First(o => o.EntityTypeMappings.Select(e => e.EntityType.Name).Contains(typeof(T).Name));
            var entityTypeMapping = entitySetMappings.EntityTypeMappings[0];
            foreach (var navigationProperty in entityTypeMapping.EntityType.NavigationProperties)
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(navigationProperty.Name);
                if (propertyInfo == null)
                    throw new InvalidOperationException("propertyInfo == null");
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                    continue;
                queryable = queryable.Include(navigationProperty.Name);
            }
            return queryable;
        }
