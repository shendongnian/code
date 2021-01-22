    public enum Decision
    {
      [DisplayText("Not Set")]
      NotSet,
      [DisplayText("Yes, that's my decision")]
      Yes,
      [DisplayText("No, that's my decision")]
      No
    }
    public static class XtensionMethods
    {
      public static string ToDisplayText(this Enum Value)
      {
        try
        {
          Type type = Value.GetType();
          MemberInfo[] memInfo =
            type.GetMember(Value.ToString());
          if (memInfo != null && memInfo.Length > 0)
          {
            object[] attrs = memInfo[0]
              .GetCustomAttributes(typeof(DisplayText), false);
            if (attrs != null && attrs.Length > 0)
              return ((DisplayText)attrs[0]).DisplayedText;
          }
        }
        catch (Exception ex)
        {
          throw new Exception(
            "Error in XtensionMethods.ToDisplayText(Enum):\r\n" + ex.Message);
        }
        return Value.ToString();
      }
   
      [System.AttributeUsage(System.AttributeTargets.Field)]
      public class DisplayText : System.Attribute
      {
        public string DisplayedText;
        public DisplayText(string displayText)
        {
          DisplayedText = displayText;
        }
      }
    }
