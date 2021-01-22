    public ActionResult UpdateWidgetColor( int id, string color )
    {
       var whitelist = new string[] { "Color" };
       Widget widget = db.Widgets.SingleOrDefault( w => w.ID == id );
       if (widget == null) ...handle missing widget error
       if (!TryUpdateModel( widget, whitelist ))
       {
          ...
       }
       else
       {
       }
    }
