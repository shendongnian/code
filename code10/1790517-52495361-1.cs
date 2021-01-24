    Public static List<string> GetForeignKeyNamesOfClass(Type classType)
    {
          List<string> foreignNameArray = new List<string>();
          PropertyInfo[] propertyInfoArray = classType.GetProperties();
          foreach(PropertyInfo info in propertyInfoArray)
          {
               if(Attribute.IsDefined(info, typeof(ForeignKeyAttribute)))
               {
                    foreignNameArray.add(info.Name)
               }
          }
          return foreignNameArray;
    }
