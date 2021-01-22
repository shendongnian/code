            foreach (System.Reflection.PropertyInfo info in typeof(BusinessEntity).GetProperties())
            {
                if (info.PropertyType.IsGenericType &&
                    info.PropertyType.Name.StartsWith("IList") &&
                    info.PropertyType.GetGenericArguments().Length > 0 &&
                        info.PropertyType.GetGenericArguments()[0] == typeof(string)
                    )
                {
                    return true;
                }
            }
