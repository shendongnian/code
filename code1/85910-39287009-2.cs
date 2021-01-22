    public class UnitTestWarningException : Exception
    {
      public UnitTestWarningException(string Message) : base(Message) { }
      public UnitTestWarningException(string Format, params object[] Args) : base(string.Format(Format, Args)) { }
    }
