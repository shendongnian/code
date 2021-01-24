    public static class TextBoxExtensions
    {
       public static int GetInt(this TextBox source)
       {
          // if TextBox null just return 0
          if (source == null)
          {
             return 0;
          }
          // if it is a valid int, return it, otherwise return 0
          // not we use string, in case someone put a space at the start or end
          return int.TryParse(source.Text.Trim(), out var value) ? value : 0;
       }
    
       public static bool HasValidInt(this TextBox source)
       {
          // if TextBox null or its not an int return false
          // otherwise return true
          return source != null && int.TryParse(source.Text.Trim(), out var _);
       }
    }
