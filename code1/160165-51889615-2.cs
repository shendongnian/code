    private static string GetPaddingSequence(int padding)
    {
          StringBuilder SB = new StringBuilder();
          for (int i = 0; i < padding; i++)
          {
               SB.Append("0");
          }
          return SB.ToString();
      }
    public static string FormatNumber(int number, int padding)
    {
        return number.ToString(GetPaddingSequence(padding));
    }
