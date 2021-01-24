    public static object ToNonAnonymousList<T>(this List<T> list, Type t)
    {
    
       //define system Type representing List of objects of T type:
       var genericType = typeof(List<>).MakeGenericType(t);
    
       //create an object instance of defined type:
       var l = Activator.CreateInstance(genericType);
    
       //get method Add from from the list:
       MethodInfo addMethod = l.GetType().GetMethod("Add");
    
       //loop through the calling list:
       foreach (T item in list)
       {
    
          //convert each object of the list into T object 
          //by calling extension ToType<T>()
          //Add this object to newly created list:
          addMethod.Invoke(l, new object[] { item.ToType(t) });
       }
    
       //return List of T objects:
       return l;
    }
