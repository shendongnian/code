    using System.ComponentModel; 
    public enum MyEnum 
    { 
        [Description("value 1")] 
        Value1, 
        [Description("value 2")]
        Value2, 
        [Description("value 3")]
        Value3
    }
    public static string GetDescription<T>( T e) 
    {
          if (e is Enum)
          {
             Type type = e.GetType();
             Array values = System.Enum.GetValues(type);
             foreach (int val in values)
             {
                  if (val == e.ToInt32(CultureInfo.InvariantCulture))
                  {
                       var memInfo = type.GetMember(type.GetEnumName(val));
                       var descriptionAttribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                    if (descriptionAttribute != null)
                    {
                          return descriptionAttribute.Description;
                     }
                }
            }
         }
 
          return null; // could also return string.Empty
    }
 
