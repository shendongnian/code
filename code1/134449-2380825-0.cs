    public class MyBasePage : System.Web.UI.Page
    {
 
      public T GetQueryStringValue<T>(
            string value,
            T defaultValue,
            bool throwOnBadConvert)
      {
        T returnValue;
        if (string.IsNullOrEmpty(value))
          return defaultValue;
        else
          returnValue = ConvertType<T>(value, defaultValue);
        if (returnValue == defaultValue && throwOnBadConvert)
          // In production code, you'd want to create a custom Exception for this
          throw new Exception(string.Format("The value specified '{0}' could not be converted to type '{1}.'", value, typeof(T).Name));
        else
          return returnValue;
      }
      // I usually have this function as a static member of a global utility class because
      // it's just too useful to only have here.
      public T ConvertType<T>(
            object value,
            T defaultValue)
      {
        Type realType = typeof(T);
        if (value == null)
          return defaultValue;
        if (typeof(T) == value.GetType())
          return (T)value;
        if (typeof(T).IsGenericType)
          realType = typeof(T).GetGenericArguments()[0];
        if (realType == typeof(Guid))
          return (T)Convert.ChangeType(new Guid((string)value), realType);
        else if (realType == typeof(bool))
        {
          int i;
          if (int.TryParse(value.ToString(), out i))
            return (T)Convert.ChangeType(i == 0 ? true : false, typeof(T));
        }
        if (value is Guid && typeof(T) == typeof(string))
          return (T)Convert.ChangeType(((Guid)value).ToString(), typeof(T));
        if (realType.BaseType == typeof(Enum))
          return (T)Enum.Parse(realType, value.ToString(), true);
        try
        {
          return (T)Convert.ChangeType(value, realType);
        }
        catch
        {
          return defaultValue;
        }
      }
    }
    public class MyPage : MyBasePage
    {
      public static class QueryStringParameters
      {
        public const string Age= "age";
      }
      public int Age
      {
        get 
        { 
         return base.GetQueryStringValue<int>(Request[QueryStringParameters.Age], -1);
        }
      }
    }
