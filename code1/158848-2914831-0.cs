       lock(e)
       {
           Entity e2 = Repository.FindByKey(e);
           if (e2 != null)
           {
               Repository.Insert(e2);
           }
           else
           {
               Repository.Update(e2);
           }
       }
