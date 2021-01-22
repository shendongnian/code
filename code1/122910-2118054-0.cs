    class MyNumber : IFormattable
    {
       decimal value;
       public MyNumber(decimal value)
       { this.value = value; }
 
       string IFormattable.ToString(string format, IFormatProvider formatProvider)
       { return value.ToString(format, formatProvider); }
 
       public string ToString(string format)
       { return ((IFormattable)this).ToString(format, System.Globalization.CultureInfo.CurrentCulture); }
    }
    class Program
    {
       static void Main(string[] args)
       {
          MyNumber num = new MyNumber(3.1415926m);
          Console.WriteLine(num.ToString("0.0000"));
          Console.WriteLine("{0:0.0000}", num);
       }
    }
