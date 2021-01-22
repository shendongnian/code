    public static string Multiply(this string source, int multiplier)
    {
       StringBuilder sb = new StringBuilder(multiplier);
       for (int i = 0; i < multiplier; i++)
       {
           sb.Append(source);
       }
    
       return sb.ToString();
    }
    
    string s = "</li></ul>".Multiply(10);
