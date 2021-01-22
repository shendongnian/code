        var setterCount =
            (from s in typeof (Entity).GetProperties(
               BindingFlags.Public 
               | BindingFlags.NonPublic 
               | BindingFlags.Instance)
             where 
               s.GetSetMethod() != null       // setter available
               && s.GetSetMethod().IsPublic   // and public
             select s)
