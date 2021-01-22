    public delegate void VoidDelegate();
    
    public static class Utils
    {
      public static void Try(VoidDelegate v) {
        try {
          v();
        }
        catch {}
      }
    }
    
    Utils.Try( () => WidgetMaker.SetAlignment(57) );
    Utils.Try( () => contactForm["Title"] = txtTitle.Text );
    Utils.Try( () => Casserole.Season(true, false) );
    Utils.Try( () => ((RecordKeeper)Session["CasseroleTracker"]).Seasoned = true );
