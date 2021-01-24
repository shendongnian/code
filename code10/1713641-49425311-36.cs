    unsafe int Calc6(ref string expression)
    {
       int res = 0, val = 0, op = 0;
       var isOp = false;
    
       // pin the array
       fixed (char* p = expression)
       {
          // Lets not evaluate this 100 million times
          var max = p + expression.Length;
    
          // lets go straight to the source and just increment the pointer
          for (var i = p; i < max; i++)
          {
             // numbers are the most common thing so lets do a loose
             // basic check for them and push them in to our val
             if (*i >= '0') { val = val * 10 + *i - 48; continue; }
    
             // The second most common thing are spaces
             if (*i == ' ')
             {
                // not every space we need to calculate
                if (!(isOp = !isOp)) continue;
    
                // In this case 4 ifs are more efficient then a switch
                // do the calculation, reset out val and jump out
                if (op == '+') { res += val; val = 0; continue; }
                if (op == '-') { res -= val; val = 0; continue; }
                if (op == '*') { res *= val; val = 0; continue; }
                if (op == '/') { res /= val; val = 0; continue; }
    
                // this is just for the first op
                res = val; val = 0; continue;                
             }
             // anything else is considered an operator
             op = *i;
          }
    
          if (op == '+') return res + val;
          if (op == '-') return res - val;
          if (op == '*') return res * val;
          if (op == '/') return res / val;
    
          throw new IndexOutOfRangeException();
       }
    }
