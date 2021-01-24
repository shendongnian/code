        public static List<DataPropertyReport> GetPrimitiveProperties<T>(T entity, string heirarchyName = null)
        {
            List<DataPropertyReport> info = new List<DataPropertyReport>();
            if (entity != null)
            {
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    Object value = property.GetValue(entity, null);
                    var name = property.Name;
                    var relatedHeirarchyName = string.IsNullOrEmpty(heirarchyName) ? name : string.Concat(heirarchyName, ".", name);
                    if (property.PropertyType != typeof(string) && property.PropertyType.IsClass)
                    {
                        var reports = GetPrimitiveProperties(value, relatedHeirarchyName);
                        info.AddRange(reports);
                    }
                    else
                    {
                        info.Add(new DataPropertyReport(relatedHeirarchyName, value != null ? value.ToString() : "", 1));
                    }
                }
            }
            return info;
        }
