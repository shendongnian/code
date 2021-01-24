    public class MyClass1 : IFoo, IBar
    {
      /* some code */
    }
    public class MyClass2 : IFoo
    {
      /* some code */
    }
    var fooList = new List<IFoo>
    {
      new MyClass1(),
      new MyClass2()
    }
    var barList = new List<IBar>();
    barList.AddRange<IFoo>(fooList);
