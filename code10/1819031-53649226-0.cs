      using System.Linq;
      using System.Reflection;
      ...
      var property = BaseList      // Give a collection
        .GetType()
        .GetGenericArguments()[0]  // Get item's type 
        .GetProperties()
        .Where(prop => 
           !prop.GetGetMethod().IsStatic &&  // not static
            prop.CanRead &&                  // readable
            prop.GetGetMethod().IsPublic &&  // public
           (typeof(IConvertible)).IsAssignableFrom(prop.PropertyType)) // convertable
        .FirstOrDefault(prop => string.Equals(prop.Name, c.Caption));  // of given name 
