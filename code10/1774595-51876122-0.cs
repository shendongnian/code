      public class Config { 
        ...
        // Get rid of this, move logic into TypeToUse
        public int ClassToUse {get { ... }}
        public Type TypeToUse {
          get {
            string name = $"DerivedClass{ClassToUse}";
            return AppDomain
             .CurrentDomain
             .GetAssemblies()         // scan all assemblies  
             .SelectMany(asm => asm
               .GetTypes()
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
