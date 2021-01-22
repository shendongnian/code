    public static MyParentEntity LoadChildren(MyParentEntity pEntity)
    { 
          using (var context = new MyObjectContext(...))
          {
               pEntity = (from e in context.MyParentEntitySet.Include("GranParentEntityReference").Include("ChildEntites") 
                          where e.Id == pEntity.Id
                          select e).FirstOrDefault();
            return pEntity;
          }
    }
