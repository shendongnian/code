       static public bool IsNumeric(string s)
       {
          double myNum = 0;
          if (Double.TryParse(s, out myNum))
          {
             if (s.Contains(",")) return false;
             return true;
          }
          else
          {
             return false;
          }
       }
