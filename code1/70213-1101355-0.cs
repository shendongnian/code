    public class MyBase
    {
        public virtual int Convert(string s)
        {
            return System.Convert.ToInt32(s);
        }
    }
    public class Derived : MyBase
    {
        public Func<string, int> ConvertFunc { get; set; }
        public override int Convert(string s)
        {
            if (ConvertFunc != null)
                return ConvertFunc(s);
            return base.Convert(s);
        }
    }
