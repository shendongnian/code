    [Test("BitShift", "", false)]
    public unsafe List<int> Convert(string input, int scale)
    {
    
       var list = new int[scale];
    
       fixed (int* plist = list)
       fixed (char* pInput = input)
       {
          var pLen = pInput + input.Length;
          var val = 0;
          var pl = plist;
          for (var p = pInput; p < pLen; p++)
             if (*p != ' ')
                val = (val << 1) + (*p - 48);
             else
             {
                *pl = val;
                pl++;
                val = 0;
             }
          *pl = val;
       }
    
       return list.ToList();
    }
