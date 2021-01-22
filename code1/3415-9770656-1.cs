        {
            Expression<Func<T, string, PropertyInfo>> GetProperty = (TypeObj, Column) => TypeObj.GetType().GetProperty(TypeObj
                .GetType().GetProperties().ToList()
                .Find(property => property.Name
                .ToLower() == Column
                .ToLower()).Name.ToString());
            return GetProperty.Compile()(obj, str);
        }
