    public unsafe static void Clear(this string s)
    {
      fixed(char* ptr = s)
      {
        for(int i = 0; i < s.Length; i++)
        {
          ptr[i] = '\0';
        }
      }
    }
