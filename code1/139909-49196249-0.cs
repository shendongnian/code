        public System.Collections.IList TableData(string tableName, ref IList<string> errors)
        {
            System.Collections.IList results = null;
            using (CRMEntities db = new CRMEntities())
            {
                Type T = db.GetType().GetProperties().Where(w => w.PropertyType.IsGenericType && w.PropertyType.GetGenericTypeDefinition() == typeof(System.Data.Entity.DbSet<>)).Select(s => s.PropertyType.GetGenericArguments()[0]).FirstOrDefault(f => f.Name == tableName);
                try
                {
                    results = Utils.CreateList(T);
                    if (T != null)
                    {
                        IQueryable qrySet = db.Set(T).AsQueryable();
                        foreach (var entry in qrySet)
                        {
                            results.Add(entry);
                        }
                    }
                }
                catch (Exception ex)
                {
                    errors = Utils.ReadException(ex);
                }
            }
            return results;
        }
        public static System.Collections.IList CreateList(Type myType)
        {
            Type genericListType = typeof(List<>).MakeGenericType(myType);
            return (System.Collections.IList)Activator.CreateInstance(genericListType);
        }
