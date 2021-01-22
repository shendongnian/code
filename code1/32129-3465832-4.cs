    public static void SplitOnce(this string value, string separator, out string part1, out string part2)
    {
      if (value!=null)
      {
        int idx=value.IndexOf(separator);
        if (idx>=0)
        {
          part1=value.Substring(0, idx);
          part2=value.Substring(idx+separator.Length);
        }
        else
        {
          part1=value;
          part2=null;
        }
      }
      else
      {
        part1="";
        part2=null;
      }
    }
