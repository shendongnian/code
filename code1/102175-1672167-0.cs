    public static LeftOrRightString(string s, string separator)
    {
      var strArr = s.Split(separator);
      if (strArr.Count != 2)
       throw new Exception();
    
      return strArr[0].Length < strArr[1].Length;
    }
