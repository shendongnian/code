    class EnumExtensions
    {
         public static string GetDescription<TEnum>(TEnum value)
             // inexpressible generic constraint TEnum : System.Enum
         {
             // reflection lookup of this value per @chibacity answer
         }
         public static IDictionary<TEnum,string> GetDescriptions<TEnum>()
             // inexpressible generic constraint TEnum : System.Enum
         {
             // do the reflection lookups once and build a dictionary
             var result = new Dictionary<TEnum, string>();
             
             foreach(string name in Enum.GetNames(typeof(TEnum))
             {
                 var value = (TEnum)Enum.Parse(typeof(TEnum), name);
                 var description = GetDescription(value);
                 result.Add(value, description);
             }
             return result;
         }
    }
