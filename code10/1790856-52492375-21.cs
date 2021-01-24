    public static string JoinLetters<T>(int space, string text)
       where T : class, IFont, new()
    {
       var font = new T();
    
       // get the letters
       var arrays = text.ToCharArray()                      
                        .Where(x => font.Mapping.ContainsKey(x))
                        .Select(x => font.Mapping[x].Invoke())
                        .ToList();
    
       // get the max height and width
       var h = arrays.Max(x => x.Length);
       var w = arrays.Max(x => x.Max(y => y.Length)) + space;
    
       var result = new string[h];
    
       // join each letter    
       // if the letter is too short, add default width
       foreach (var array in arrays)
          for (var j = 0; j < h; j++)
             result[j] += (j >= array.Length ? " " : array[j]).PadRight(w);
    
       return string.Join(Environment.NewLine, result);
    }
