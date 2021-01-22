    public static class EnumExtensions
    {
      public static T GetAttribute<T>(this Enum enumerationValue) where T : Attribute
      {
        T[] attributes = GetAttributes<T>(enumerationValue);
        return attributes.Length > 0 ? attributes[0] : null;
      }
      
      public static string GetDescription(this Enum enumerationValue, string descriptionIfNull = "")
      {
        if (enumerationValue != null)
        {
          DescriptionAttribute attribute = enumerationValue.GetAttribute<DescriptionAttribute>();
          return attribute != null ? attribute.Description : enumerationValue.ToString();
        }
        return descriptionIfNull;
      }
    }
