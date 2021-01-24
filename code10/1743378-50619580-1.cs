    public static bool IsEqual<T>(int index, params List<T>[] ary)
    {
       for (var i = 1; i < ary.Length; i++)
          if (!EqualityComparer<T>.Default.Equals(ary[0][index], ary[i][index]))
             return false;         
    
       return true;
    }
