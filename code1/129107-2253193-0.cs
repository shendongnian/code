    static class Extensions
    {
         public static string Times(this string s, int count)
         {
              StringBuilder sb = new StringBuilder(count * s.Length);
              for (int i = 0; i < count; i++)
              {
                  sb.Append(s);
              }
              return sb.ToString();
         }
    }
