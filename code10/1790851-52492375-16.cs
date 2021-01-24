    public static string JoinLetters<T>(int space, string text)
       where T : class, IFont, new()
    {
       var font = new T();
    
       // get the letters
       var arrays = text.ToCharArray()
                        .Select(x => font.Mapping[x].Invoke())
                        .ToList();
    
       // get the max height
       var h = arrays.Max(x => x.Length);
    
       // get the max letter width
       var w = arrays.Max(x => x.Max(y => y.Length));
    
       var result = new string[h];
    
       // join each letter    
       foreach (var array in arrays)
          for (var j = 0; j < h; j++)
          {
             // Add padding space
             result[j] += new string(' ', space);
    
             // if the letter is too short, add default width
             if (j >= array.Length)
                result[j] += new string(' ', w);
             else
                result[j] += array[j].PadRight(w);
          }
    
       return string.Join(Environment.NewLine, result);
    }
