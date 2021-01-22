        var setterCount =
            (from s in typeof (Entity).GetProperties(
               BindingFlags.Public 
               | BindingFlags.NonPublic 
               | BindingFlags.Instance)
             where 
               s.CanWrite // Set method available
               && s.GetSetMethod().IsPublic // and public
             select s)
