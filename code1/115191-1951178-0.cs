    FlashObject.cs:
    namespace MyNamespace 
    { 
     using System.Web.UI;
    public class FlashObject : Control
    { public int Width  {get;set}
       public int Height {get;set}
       [UrlProperty] pubic string SourceUrl {get;set;}
      protected override Render(HtmlWriter writer)
       { writer.WriteLine( "<object type='application/x-shockwave-flash' "
                       +" data='{0}' width='{1}' height='{2}'>\r\n"
                       +"    <param name='movie' value='{0}'>\r\n</object>"
                       ,ResolveUrl(SourceUrl)
                       ,Width
                       ,Height);
       }
    }
    }
