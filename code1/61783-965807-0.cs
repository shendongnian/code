    public class MyHtmlHelper : HtmlHelper
    {
      // Take helper service, implement special methods
    }
    
    public class MyViewPage : ViewPage
    {
      protected new MyHtmlHelper HtmlHelper { get; set; }
      // Wire up HtmlHelper as appropriate -- which is not going to be easy since
      // the base property could be set at any time.
    }
