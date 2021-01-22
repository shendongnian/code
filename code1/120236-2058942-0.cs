    public class DerivedDataClass : DataClass
    {
      new public DerivedDataClass PreviousInstance
      {
         get { return (DerivedDataClass)base.PreviousInstance; }
         set { base.PreviousInstance = value; }
      }
    }
