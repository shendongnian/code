    public static void ChangeContainerFont(Gtk.Container container, string fontDesc)
    {
        ChangeWidgetFont( container, fontDesc );
        foreach(Gtk.Widget subw in container.Children) {
            ChangeWidgetFont( subw, fontDesc );
            if ( subw is Gtk.MenuItem menuItem ) {
                ChangeContainerFont( menuItem, fontDesc );
                if ( menuItem.Submenu is Gtk.Menu subMenu) {
                    ChangeContainerFont( subMenu, fontDesc );
                }
            }
            else
            if ( subw is Gtk.Container subContainer ) {
                ChangeContainerFont( subContainer, fontDesc );
            }
        }
    }
    
    public static void ChangeWidgetFont(Gtk.Widget w, string fontDesc)
    {
        w.ModifyFont( Pango.FontDescription.FromString( fontDesc ) );
    }
