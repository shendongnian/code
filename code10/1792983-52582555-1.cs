    public class PasswordRequirements : IPasswordRequirements
    {
      public int MaxLength { get; set; }
      public int NoUpper { get; set; }
      public int NoLower { get; set; }
      public int NoNumeric { get; set; }
      public int NoSpecial { get; set; }
    }
