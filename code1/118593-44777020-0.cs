    public abstract BaseClass
    {
      public double MyPoP { get { return GetMyPoP; } }
      protected abstract double GetMyPoP { get; }
    }
    public class DClass: BaseClass
    {
      public new double MyPoP { get; set; }
      protected override double GetMyPop { get { return MyPoP; } }
    }
