    public unsafe static int? FindInt(string val)
    {
       var result = 0;
       fixed (char* p = val)
       {
          for (var i = 0; i < val.Length; i++)
          {
             if (*p == ':')return result;
             result = result * 10 + *p - 48;
          }
    
          return null;
       }
    }
