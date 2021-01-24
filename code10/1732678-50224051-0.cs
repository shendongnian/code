    private static int GetIntValue(string text)
    {
       if(int.TryParse(text, out int value))
       {
          return value;
       }
       else
       {
         // TODO: action when user enters not int
       }
    }
    
    private static Direction GetDirectionValue(string text)
    {
       if(Enum.TryParse(text, out Direction value)
       {
          return value;
       }
       else
       {
         // TODO: action when user enters not enum
       }
    }
