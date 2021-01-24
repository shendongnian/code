      using System.Linq;
      using System.Reflection;
      ...
      var property = BaseList      // Given a collection...
        .GetType()
        .GetGenericArguments()[0]  // Get collection's item type 
        .GetProperties()
        .Where(prop => 
            prop.CanRead &&                  // readable  
           !prop.GetGetMethod().IsStatic &&  // not static
            prop.GetGetMethod().IsPublic &&  // public
           (typeof(IConvertible)).IsAssignableFrom(prop.PropertyType)) // convertable
        .FirstOrDefault(prop => string.Equals(prop.Name, c.Caption));  // of given name 
