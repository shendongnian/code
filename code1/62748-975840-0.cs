    [AttributeUsage( AttributeTargets.Property )]
    public sealed class UnitAttribute : Attribute
    {
      public UnitAttribute( Unit unit )
      {
        Unit = unit;
      }
      public Unit Unit { get; private set; }
    }
