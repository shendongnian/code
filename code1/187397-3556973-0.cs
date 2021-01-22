    public class Formatter
    {
      List<char> symbols;
      int base;
    
      public Formatter(string format)
      {
        string[] splitted = format.Split(",");
        symbols = splitted.Select(x => x[0]).ToList();
        base = symbols.Size;
      }
    
      public long Parse(string value)
      {
        long result = 0;
        foreach(char c in value)
        {
          long n = symbols.IndexOf(c);
          result = result*base+n;
        }
        return result;
      }
    
      public string Encode(long value)
      {
        StringBuilder sb = new StringBuilder();
        while(value>0)
        {
          long n = value % base;
          value /= base;
          sb.Insert(0, symbols[n]);
        }
        return sb.ToString();
      }
    }
