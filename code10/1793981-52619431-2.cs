    foreach (var prop in entity.GetProperties())
            {
                var attr = prop.PropertyInfo?.GetCustomAttribute<ClusteredAttribute>(true);
                if (attr != null)
                {
                    var index = entity.AddIndex(prop);
                    index.IsUnique = true;
                    index.SqlServer().IsClustered = true;
                }
            }
