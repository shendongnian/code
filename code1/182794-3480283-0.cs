    public class DataGridHelper
    {
       public Wrapper(object o)
       {
          ClassA a = o as ClassA;
          if (a != null)
          {
             Column1 = a.Property1;
             Column2 = a.Property2;
             ...
          }
          ClassB b = o as ClassA;
          if (b != null)
          {
             Column1 = b.Property1;
             Column2 = b.Property2;
             ...
          }
          public object Column1 { get; private set; }
          public object Column2 { get; private set; }
    }
