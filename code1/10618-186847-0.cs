       public class TypeDictionary
    
       {
    
           private class InnerTypeDictionary<T>
    
           {
    
               static WeakDictionary<TypeDictionary, T> _innerDictionary = new WeakDictionary<TypeDictionary, T>();
    
               public static void Add(TypeDictionary dic, T value)
    
               {
    
                   _innerDictionary.Add(dic, value);
    
               }
    
               public static T GetValue(TypeDictionary dic)
    
               {
    
                   return _innerDictionary[dic];
    
               }
    
           }
    
           public void Add<T>(T value)
    
           {
    
               InnerTypeDictionary<T>.Add(this, value);
    
           }
    
           public T GetValue<T>()
    
           {
    
               return InnerTypeDictionary<T>.GetValue(this);
    
           }
    
       }
