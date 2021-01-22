    using System;
    using System.Reflection;
    public class TextAttribute : Attribute
    {
        public string Text;
        public TextAttribute(string text)
        {
            Text = text;
        }
    }  
    public static class EnumExtender
    {
        public static string ToText(this Enum enumeration)
        {
            var memberInfo = enumeration.GetType().GetMember(enumeration.ToString());
            if (memberInfo.Length <= 0) return enumeration.ToString();
    
            var attributes = memberInfo[0].GetCustomAttributes(typeof(TextAttribute), false);
            return attributes.Length > 0 ? ((TextAttribute)attributes[0]).Text : enumeration.ToString();
        }
    }
