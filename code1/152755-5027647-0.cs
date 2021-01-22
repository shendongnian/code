    public abstract class SomeAbstractClass : ISomeInterface
    {
      public TargetType ToTargetType()
      {
        return (TargetType)this;
      }
      public static explicit operator TargetType(SomeAbstractClass obj)
      {
        //Actual cast logic goes here
      }
    }
