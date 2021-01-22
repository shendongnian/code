    public static T Find<T>(this List<T> list, Predicate<T> match, out bool found)
    {
    	found = false;
    
      for (int i = 0; i < list.Count; i++)
      {
        if (match(list[i]))
        {
    			found = true;
          return list[i];
        }
      }
      return default(T);
    }
