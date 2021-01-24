    Public static List<string> GetForeignKeyNamesOfClass(Type classType)
    {
          List<string> foreignNameList = new List<string>();
          PropertyInfo[] propertyInfoArray = classType.GetProperties();
          foreach(PropertyInfo info in propertyInfoArray)
          {
               if(Attribute.IsDefined(info, typeof(ForeignKeyAttribute)))
               {
                    foreignNameList.add(info.Name)
               }
          }
          return foreignNameList;
    }
