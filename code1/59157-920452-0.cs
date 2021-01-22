     public static class StringExtensions
     {
          public static bool IsNumeric( this string source )
          {
              if (string.IsNullOrEmpty( source ))
              { 
                   return false;
              }
              ...
          }
          public static bool IsMoney( this string source )
          {
              ...
          }
          ...
     }
