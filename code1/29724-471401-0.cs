    public class Wrapper
    {
     private Regex _regex;
     public Wrapper(string pattern)
     {
      _regex = new Regex(pattern);
     }
    }
