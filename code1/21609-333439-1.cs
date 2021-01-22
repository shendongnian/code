    public class CustomPage : System.Web.UI.Page
    {
      public CustomPage()
      { }
    
      protected override void OnPreRender(EventArgs e)
      {
        base.OnPreRender(e);
    
        if (Context.Items["custom"] == null)
        {
          return;
        }
    
        PlaceHolder placeHolder = this.FindControl("pp") as PlaceHolder;
        if (placeHolder == null)
        {
          return;
        }
    
        Label addedContent = new Label();
        addedContent.Text = Context.Items["custom"].ToString();
        placeHolder .Controls.Add(addedContent);
        
      }
    
    }
