    public class TwoType: MyClass<TwoType>
    {
      public override MyClass<OneType> GetMyClass()
      {
          return new SubClass(this);
      }
    }
