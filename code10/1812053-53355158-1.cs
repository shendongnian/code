     public IQueryable<T> search(IQueryable<T> query, params Tuple<string, string>[] parameters)
     {
       Type type = typeof(T);
       PropertyInfo[] properties = type.GetProperties();
       foreach(var parameter in parameters)
       {
         PropertyInfo pi = properties.Where(a => a.Name == parameter.Item1).FirstOrDefault();
         if (pi != null)
         {
           query = query.Where(a => pi.GetValue(a).ToString().Contains(parameter.Item2));
         }
       }
       return query;
     }
