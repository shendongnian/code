     public static T GetById<T, Y>(this ObjectSet<T> entitySet, Y Id) 
            where T : EntityObject 
          
        {
            return entitySet.Where(
                    e => 
                        e.EntityKey.EntityKeyValues.Select(
                            v => EqualityComparer<Y>.Default.Equals((Y)v.Value, Id)
                        ).Count() > 0)
                    .First();            
        }
