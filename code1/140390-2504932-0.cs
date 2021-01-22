    public static IList<string> GetDifferingProperties(object source, object target)
    {
      var sourceType = source.GetType();
      var sourceProperties = sourceType.GetProperties();
      var targetType = target.GetType();
      var targetProperties = targetType.GetProperties();
    
      var result = new List<string>();
    
      foreach (var property in
          (from s in sourceProperties
           from t in targetProperties
           where s.Name == t.Name &&
           s.PropertyType == t.PropertyType &&
           !Equals(s.GetValue(source, null), t.GetValue(target, null))
           select new { Source = s, Target = t }))
      {
        // it's up to you to decide how primitive is primitive enough
        if (IsPrimitive(property.Source.PropertyType))
        {
          result.Add(property.Source.Name);
        }
        else
        {
          foreach (var subProperty in GetDifferingProperties(
              property.Source.GetValue(source, null),
              property.Target.GetValue(target, null)))
          {
            result.Add(property.Source.Name + "." + subProperty);
          }
        }
      }
    
      return result;
    }
    
    private static bool IsPrimitive(Type type)
    {
      return type == typeof(string) || type == typeof(int);
    }
