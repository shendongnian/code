        var setterCount =
            (from s in typeof (Entity).GetProperties(
               BindingFlags.Public 
               | BindingFlags.NonPublic 
               | BindingFlags.Instance)
             where 
               s.GetSetMethod() != null       // public setter available
             select s)
