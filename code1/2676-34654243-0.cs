      public static class Enum<T> where T : struct
      {
         private static readonly IEnumerable<T> All = Enum.GetValues(typeof (T)).Cast<T>();
         private static readonly Dictionary<int, T> Values = All.ToDictionary(k => Convert.ToInt32(k));
         public static T? CastOrNull(int value)
         {
            T foundValue;
            if (Values.TryGetValue(value, out foundValue))
            {
               return foundValue;
            }
            // For enums with Flags-Attribut.
            try
            {
               bool isFlag = typeof(T).GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0;
               if (isFlag)
               {
                  int existingIntValue = 0;
                  foreach (T t in Enum.GetValues(typeof(T)))
                  {
                     if ((value & Convert.ToInt32(t)) > 0)
                     {
                        existingIntValue |= Convert.ToInt32(t);
                     }
                  }
                  if (existingIntValue == 0)
                  {
                     return null;
                  }
                  return (T)(Enum.Parse(typeof(T), existingIntValue.ToString(), true));
               }
            }
            catch (Exception)
            {
               return null;
            }
            return null;
         }
      }
