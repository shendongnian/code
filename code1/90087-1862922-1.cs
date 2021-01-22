    public class FooExtension : MarkupExtension
    {
      public string Bar {get; set;}
      public ImgPathExtension(string bar)
      {
        this.Bar = bar;
      }
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
        var foo = new Foo(this.Bar);
        return foo;
      }
    }
