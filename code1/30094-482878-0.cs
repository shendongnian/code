    public class LoggingPage : : System.Web.UI.Page
    {
      public override void OnLoad()
    {
    // Do logging
    }
    }
    
    partial class OneOfTheWebPages : LoggingPage
    {
     public void onLoad()
    {
    base.onLoad();
    }
    }
