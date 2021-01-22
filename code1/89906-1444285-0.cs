    private static void displayObject(object myObject, bool displaySubObject, Type objectType)
    {
      print(objectType.FullName);
      if (myObject == null) 
      {
          print(STR_Null);
      }
      else 
      {
        //check for collection
        if (objectType.GetInterface("IEnumerable") != null) 
        {
          int itemNb = 0;
          foreach (object item in (IEnumerable)myObject) 
          {
            displayObject(item, displaySubObject, item.GetType);
            itemNb += 1;
          }
        }
        else 
        {
          ArrayList al = new ArrayList();
          Reflection.PropertyInfo pi = default(Reflection.PropertyInfo);
          Reflection.MemberInfo[] members = objectType.GetMembers();
          foreach (Reflection.MemberInfo mi in objectType.GetMembers()) 
          {
            if ((mi.MemberType & Reflection.MemberTypes.Constructor) != 0){//ignore constructor}
            else if (object.ReferenceEquals(mi.DeclaringType, typeof(object))) {//ignore inherited}
            else if (!al.Contains(mi.Name) & (mi.MemberType & Reflection.MemberTypes.Property) != 0) 
            {
              al.Add(mi.Name);
              pi = (Reflection.PropertyInfo)mi;
              if (!(displaySubObject) || (pi.PropertyType.IsValueType || pi.PropertyType.Equals(typeof(string)))) 
              {
                print(pi, myObject);
              }
              else 
              {
                //display sub objects
                displayObject(pi.GetValue(myObject, null), displaySubObject, i.PropertyType);
              }
            }
          }
        }
      }
    }
