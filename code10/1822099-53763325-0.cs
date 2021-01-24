     public List<Union100> Get(String IdType)
     {
         for (var i = 0;i <= 3; i++)
         {
             try
             {
                 var typeIdOfObjectType = db.Objects.Where(x => x.ObjectsName == ObjectTypeName).Select(x => x.ObjectTgId).FirstOrDefault();
                 var d = GetParent();
             }
             catch{}
         }
     }
