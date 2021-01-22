    [ContentProperty("Geometry")]
    public class ConvertToStreamGeometry : MarkupExtension
    {
      public Geometry Geometry { get; set; }
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
        var result = new StreamGeometry();
        using(var ctx = result.Open())
          ctx.DrawGeometry(Geometry);
        return result;
      }
    }
