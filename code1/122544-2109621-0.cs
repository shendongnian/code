    class MyClass
    {
      private double dd;
      private string prefix = "MyDouble:";
      ...
      ...
        public override string ToString()
        {
            if (dd.GetType().Name == "Double")
            return ( prefix + Math.Round(dd, 5).ToString() );
        }
    }
