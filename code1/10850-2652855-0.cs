      if (col <= 26) { 
        return Convert.ToChar(col + 64).ToString();
      }
      int div = col / 26;
      int mod = col % 26;
      if (mod == 0) {mod = 26;div--;}
      return ColumnAdress(div) + ColumnAdress(mod);
    }
    public static int ColumnNumber(string colAdress)
    {
      int[] digits = new int[colAdress.Length];
      for (int i = 0; i < colAdress.Length; ++i)
      {
        digits[i] = Convert.ToInt32(colAdress[i]) - 64;
      }
      int mul=1;int res=0;
      for (int pos = digits.Length - 1; pos >= 0; --pos)
      {
        res += digits[pos] * mul;
        mul *= 26;
      }
      return res;
    }
