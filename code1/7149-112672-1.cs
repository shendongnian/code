    public class FromDecimal<T> where T : struct, IConvertible
    {
        public T GetFromDecimal(decimal Source)
        {
            T myValue = default(T);
            myValue = (T) Convert.ChangeType(Source, myValue.GetTypeCode());
            return myValue;
        }
    }
    public class FromDecimalTestClass
    {
        public void TestMethod()
        {
            decimal a = 1.1m;
            var Inter = new FromDecimal<int>();
            int x = Inter.GetFromDecimal(a);
            int? y = Inter.GetFromDecimal(a);
            Console.WriteLine("{0} {1}", x, y);
            var Doubler = new FromDecimal<double>();
            double dx = Doubler.GetFromDecimal(a);
            double? dy = Doubler.GetFromDecimal(a);
            Console.WriteLine("{0} {1}", dx, dy);
        }
    }
----------
    private T? Getvalue()
    {
      T? value = null;
      if (this.HasValue)
        value = new FromDecimal<T>().GetFromDecimal(NumericUpDown);
      return value;
    }
