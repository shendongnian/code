      public class Lazy<T> where T : new()
       {
           private T _value;
           private bool _isInitialized;
           private T GetValue()
           {
               if (!_isInitialized)
               {
                   _value = new T();
                   _isInitialized = true;
               }
               return _value;
           }
           public static implicit operator T (Lazy<T> t)
           {
               return t.GetValue();
           }
       }
