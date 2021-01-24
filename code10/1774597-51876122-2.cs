    public class Config { 
      ...
      // Get rid of this, move logic into TypeToUse
      public int ClassToUse {get { ... }}
      public Type TypeToUse {
        get {
          string name = $"DerivedClass{ClassToUse}";
          // Here we scan all types in order to find out the best one. Class must be
          //   1. Derived from BaseClass
          //   2. Not Abstract (we want to create an instance)
          // Among these classes we find the required by its name DerivedClass[1..3]
          // (as a patch). You should implement a more elaborated filter
          // If we have several candidates we'll take the 1st one
          return AppDomain
            .CurrentDomain
            .GetAssemblies()         // scan all assemblies  
            .SelectMany(asm => asm
              .GetTypes()            // and all types 
              .Where(tp => typeof(BaseClass).IsAssignableFrom(tp))) // ... for derived classes
           .Where(tp => !tp.IsAbstract)       //TODO: Add more filters if required
           .Where(tp => tp.Name.Equals(name)) //TODO: put relevant filter here 
           .FirstOrDefault();            
        }
      } 
      public BaseClass CreateInstance() {
        Type tp = TypeToUse;
        if (tp == null)
          return null; // Or throw exception
        return Activator.CreateInstance(tp, this) as BaseType;
      } 
    } 
