     public class ParentClass
     {
          private ReferencedClass _reference;
          public ReferencedClass Reference
          {
              get
              { 
                  return _reference;
              }
              set
              {
                  // don't assign the value, but consult the
                  // static dictionary to see if we already have
                  // the singleton
                  _reference = StaticCache.GetSingleton(value);
              }
          }
     }
