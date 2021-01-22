    public enum ErrorLevel
    {
      None,
      Low,
      High,
      SoylentGreen
    }
    
    public static class ErrorLevelExtensions
    {
      public static string ToFriendlyString(this ErrorLevel me)
      {
        switch(me)
        {
          case ErrorLevel.None:
            return "Everything is OK";
          case ErrorLevel.Low:
            return "SNAFU, if you know what I mean.";
          case ErrorLevel.High:
            return "Reaching TARFU levels";
          case ErrorLevel.SoylentGreen:
            return "ITS PEOPLE!!!!";
        }
      }
    }
