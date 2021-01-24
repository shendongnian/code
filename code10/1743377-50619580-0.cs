    public bool IsEqual<T>(int index, params List<T>[] ary)
    {
       for (var i = 1; i < ary.Length; i++)
          if (!EqualityComparer<T>.Default.Equals(ary[index][0], ary[index][i]))
             return false;         
    
       return true;
    }
