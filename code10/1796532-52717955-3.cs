    IEnumerable<DiffPropertyInfo> ExtractProperties(int Id, TSource original, TSource alternative)
    {
         // examine only readable properties that can be changed:
         IEnumerable<PropertyInfo> propertyInfos = typeof(TSource)
            .GetProperties()
            .Where(property => property.CanRead && property.CanWrite);
         // the following can be done as one LINQ statement
         // for readability I'll use yield return
         foreach (PropertyInfo propertyInfo in propertyInfos
         {
             yield return new DiffPropertyInfo()
             {
                  Id = Id,
                  OriginalValue = original,
                  AlternativeValue = alternative,
                  PropertyInfo = propertyInfo, 
             };
         }
    }
