     public IQueryable<T> search(IQueryable<T> query, params string[][] parameters)
     {
       Type type = typeof(T);
       PropertyInfo[] properties = type.GetProperties();
       foreach(string[] parameter in parameters)
       {
         PropertyInfo pi = properties.Where(a => a.Name == parameter[0]).FirstOrDefault();
         if (pi != null)
         {
           query = query.Where(a => pi.GetValue(a).ToString().Contains(parameter[1]));
         }
       }
       return query;
     }
