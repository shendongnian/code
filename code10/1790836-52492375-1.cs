    public static string JoinLetters(int space, params Func<string[]>[] args)
    {
       // get your letters
       var arrays = args.Select(x => x.Invoke()).ToList();
    
       // get the max height
       var h = arrays.Max(x => x.Length);
       // Allocate a result
       var result = new string[h];
    
       // itterate letters and lines and join them
       foreach (var array in arrays)
          for (var j = 0; j < array.Length; j++)
             result[j] += new string(' ', space) + array[j];
    
       // put new joined array elems on new lines
       return string.Join(Environment.NewLine, result);    
    }
