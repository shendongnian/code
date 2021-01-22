    public class MyWebControl : WebControl
    {
      
      /* Your code 
                 between here */
      protected override void Render(HtmlTextWriter writer)
      {
        RenderContents (writer);
      }
    }
