    public static class UrlPath
    {
       private static string InternalCombine(string source, string dest)
       {
          if (string.IsNullOrWhiteSpace(source))
             throw new ArgumentException("Cannot be null or white space", nameof(source));
                
          if (string.IsNullOrWhiteSpace(dest))
             throw new ArgumentException("Cannot be null or white space", nameof(dest));
    
          return $"{source.TrimEnd('/', '\\')}/{dest.TrimStart('/', '\\')}";
       }
    
       public static string Combine(string source, params string[] args) 
           => args.Aggregate(source, InternalCombine);
    }
