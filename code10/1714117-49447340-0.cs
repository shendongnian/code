     public static string GetProp(string[] classes, object oldObj)
     {
     var obj = oldObj.GetType().GetProperty(classes[0]).GetValue(oldObj, null);
     if(classes.Length>1)
       {
        classes = classes.Skip(1).ToArray();
        return GetProp(classes, obj);
       }
          return obj.ToString();
     }
   
