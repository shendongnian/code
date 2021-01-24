    public static string JoinLetters(int space, params Func<string[]>[] args)
    {
       // get the letters
       var arrays = args.Select(x => x.Invoke()).ToList();
    
       // get the max height
       var h = arrays.Max(x => x.Length);
       // get the max letter width
       var w = arrays.Max(x => x.Max(y => y.Length));
       var result = new string[h];
    
       // make sure to cater for short letters
       foreach (var array in arrays)
          for (var j = 0; j < h; j++)      
             result[j] += new string(' ', space) + (j>=array.Length? new string(' ', w) :( array[j]).PadRight(w));
    
       return string.Join(Environment.NewLine, result);
    
    }
