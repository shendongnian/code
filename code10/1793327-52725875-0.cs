    class Claim {
      [Computed]
      public string Name
        => $"{FirstName} {LastName}";
    }
    
    class ClaimType {
      [Computed]
      public override string ToString()
        => Value + (Abbrev != null ? $" ({Abbrev})" : "");
    }
