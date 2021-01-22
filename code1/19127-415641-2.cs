    /// <summary>
    /// Provides a static utility object of methods and properties to interact
    /// with enumerated types.
    /// </summary>
    public static class EnumHelper
    {
       /// <summary>
       /// Gets the <see cref="DescriptionAttribute" /> of an <see cref="Enum" /> 
       /// type value.
       /// </summary>
       /// <param name="value">The <see cref="Enum" /> type value.</param>
       /// <returns>A string containing the text of the
       /// <see cref="DescriptionAttribute"/>.</returns>
       public static string GetDescription(this Enum value)
       {
          if (value == null)
          {
             throw new ArgumentNullException("value");
          }
    
          string description = value.ToString();
          FieldInfo fieldInfo = value.GetType().GetField(description);
          EnumDescriptionAttribute[] attributes =
             (EnumDescriptionAttribute[])
           fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
    
          if (attributes != null && attributes.Length > 0)
          {
             description = attributes[0].Description;
          }
          return description;
       }
    
       /// <summary>
       /// Converts the <see cref="Enum" /> type to an <see cref="IList" /> 
       /// compatible object.
       /// </summary>
       /// <param name="type">The <see cref="Enum"/> type.</param>
       /// <returns>An <see cref="IList"/> containing the enumerated
       /// type value and description.</returns>
       public static IList ToList(this Type type)
       {
          if (type == null)
          {
             throw new ArgumentNullException("type");
          }
    
          ArrayList list = new ArrayList();
          Array enumValues = Enum.GetValues(type);
    
          foreach (Enum value in enumValues)
          {
             list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
          }
    
          return list;
       }
    } 
