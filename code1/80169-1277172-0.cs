    pulic class TemplateViewerPage : System.Web.UI.Page
    {
      protected override void OnLoad(EventArgs e)
      {
        // load your properties from session or database.
        base.OnLoad(e);
      }
      
      // your property
      public string Subject{ set; get;}
      public string MessageBody{ set; get;}
    }
