    public static string RemoveSpecialCharacters(string str) {
       StringBuilder sb = new StringBuilder();
       foreach (char c in str) {
          if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'z' || (c == '.' || c == '_'))) {
             sb.Append(c);
          }
       }
       return sb.ToString();
    }
