    public static string DoStuff(int levels,string input)
    {
       // create a stack this reduces lots of string allocations
       var stack = new Stack<(int l, char c)>(input.ToCharArray().Select(x => (1, x)));
    
       // accumulate in a string builder this reduces lots of string allocation
       var sb = new StringBuilder();
       while (stack.Any())
       {
          // pop the next
          var val = stack.Pop();
    
          // limit the levels
          if (val.l < levels)
          {
             // add to stack if needed
             if (val.c == 'a')
                foreach (var c in a)
                   stack.Push((val.l + 1, c));
             else if (val.c == 'b')
                foreach (var c in b)
                   stack.Push((val.l + 1, c));
             else
                sb.Append(val.c); // append the string
          }
          else
          {
             // level limit, just append
             if (val.c == 'a')
                sb.Append(a);
             else if (val.c == 'b')
                sb.Append(b);
             else
                sb.Append(val.c);
          }
       }
    
       // the results come out in reverse, so we need to reverse the string
       var charArray = sb.ToString().ToCharArray();
       Array.Reverse(charArray);
       return new string(charArray);
    
    }
