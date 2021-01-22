    public static Dictionary<string, object> StripAnonymousNulls(this object attributes)
      {
         var ret = new Dictionary<string, object>();
         foreach (var prop in attributes.GetType().GetProperties())
         {
            var val = prop.GetValue(attributes, null);
            if (val != null)
               ret.Add(prop.Name, val);
         }
         return ret;
      }
