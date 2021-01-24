    public static string OriginalVersion(int levels, string input)
    {
       for (int n = 0; n < levels; n++)
       {
          for (var i = 0; i < input.Length; i++)
          {
             if (i < input.Length && input[i] == 'a')
             {
                input = input.Remove(i, 1);
                input = input.Insert(i, a);
                i += a.Length;
             }
    
             if (i < input.Length && input[i] == 'b')
             {
                input = input.Remove(i, 1);
                input = input.Insert(i, b);
                i += b.Length;
             }
          }
       }
    
       return input;
    }
