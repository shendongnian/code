    public class Foo
    {
       private string[] bar;
       public string FooBar
       {
           get { return bar.Length > 4 ? bar[4] : null; }
       }
    }
