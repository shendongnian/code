    public static void ChangeContainerFont(Gtk.Container container, string fontDesc)
    {
        ChangeWidgetFont( container, fontDesc );
    
        foreach(Gtk.Widget subw in container.Children) {
            var subContainer = subw as Gtk.Container;
                        
            if ( subContainer != null ) {
                ChangeContainerFont( subContainer, fontDesc );
            } else {
                ChangeWidgetFont( subw, fontDesc );
            }
        }
    }
    
    public static void ChangeWidgetFont(Gtk.Widget w, string fontDesc)
    {
        w.ModifyFont( Pango.FontDescription.FromString( fontDesc ) );
    }
