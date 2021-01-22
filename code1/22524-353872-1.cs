    static class SBExtention
    {
      static string AppendCollection<T>(this StringBuilder sb, 
                                        IEnumerable<T> coll, 
                                        Func<T,string> action)
      {
           foreach(T t in coll)
           {
              sb.Append(action(t));
              sb.Append("\n");
           }
           return sb.ToString();
    
      }
    }
