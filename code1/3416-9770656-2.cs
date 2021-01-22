    private bool NullTest<T>(T[] list, string attribute)
        {
            bool status = false;
            if (list != null)
            {
                int flag = 0;
                var property = GetProperty(list.FirstOrDefault(), attribute);
                foreach (T obj in list)
                {
                    if (property.GetValue(obj, null) == null)
                        flag++;
                }
                status = flag == 0 ? true : false;
            }
            return status;
        }
    public PropertyInfo GetProperty<T>(T obj, string str)
        {
            Expression<Func<T, string, PropertyInfo>> GetProperty = (TypeObj, Column) => TypeObj.GetType().GetProperty(TypeObj
                .GetType().GetProperties().ToList()
                .Find(property => property.Name
                .ToLower() == Column
                .ToLower()).Name.ToString());
            return GetProperty.Compile()(obj, str);
        }
