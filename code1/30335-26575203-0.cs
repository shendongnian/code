    namespace EnumExtensions {
    
    using System;
    using System.Reflection;
    
    public class TextAttribute : Attribute {
       public string Text;
       public TextAttribute( string text ) {
          Text = text;
       }//ctor
    }// class TextAttribute
    
    public static class EnumExtender {
    
    public static string ToText( this Enum enumeration ) {
    
       MemberInfo[] memberInfo = enumeration.GetType().GetMember( enumeration.ToString() );
    
       if ( memberInfo != null && memberInfo.Length > 0 ) {
    
          object[] attributes = memberInfo[ 0 ].GetCustomAttributes( typeof(TextAttribute),  false );
    
          if ( attributes != null && attributes.Length > 0 ) {
             return ( (TextAttribute)attributes[ 0 ] ).Text;
          }
    
       }//if
    
       return enumeration.ToString();
    
    }//ToText
    
    }//class EnumExtender
    
    }//namespace
