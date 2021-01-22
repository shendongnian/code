    /// <summary>
        /// Get entities from DataTable
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public IEnumerable<T> GetEntities<T>(DataTable dt)
        {
            if (dt == null)
            {
                return null;
            }
            List<T> returnValue = new List<T>();
            List<string> typeProperties = new List<string>();
            T typeInstance = Activator.CreateInstance<T>();
            foreach (DataColumn column in dt.Columns)
            {
                var prop = typeInstance.GetType().GetProperty(column.ColumnName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (prop != null)
                {
                    typeProperties.Add(column.ColumnName);
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                T entity = Activator.CreateInstance<T>();
                foreach (var propertyName in typeProperties)
                {
                    if (row[propertyName] != DBNull.Value)
                    {
                        string str = row[propertyName].GetType().FullName;
                        if (entity.GetType().GetProperty(propertyName).PropertyType == typeof(System.String))
                        {
                            object Val = row[propertyName].ToString();
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, Val, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                        else if (entity.GetType().GetProperty(propertyName).PropertyType == typeof(System.Guid)) 
                        {
                            object Val = Guid.Parse(row[propertyName].ToString());
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, Val, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                        else
                        {
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, row[propertyName], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                    }
                    else
                    {
                        entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, null, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                    }
                }
                returnValue.Add(entity);
            }
            return returnValue.AsEnumerable();
        }
