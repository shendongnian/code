      public static IEnumerable<TEnum> GetValues(bool includeFirst)
      {
         var result = ((TEnum[])Enum.GetValues(typeof(TEnum)))
            .ToList();
         if (!includeZero)
         {
            result = result.Where(r => r != default).ToList();
         }
         return result;
      }
