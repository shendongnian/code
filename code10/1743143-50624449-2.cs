    public static void ChangeContainerFont(Gtk.Container container, string fontDesc)
    {
        ChangeWidgetFont( container, fontDesc );
        foreach(Gtk.Widget subw in container.Children) {
            ChangeWidgetFont( subw, fontDesc );
            if ( subw is Gtk.MenuItem menuItem ) {
                var subMenu = menuItem.Submenu;
                ChangeContainerFont( menuItem, fontDesc );
                if ( subMenu is Gtk.Container subContainer ) {
                    ChangeContainerFont( subContainer, fontDesc );
                } else {
                    if ( subMenu != null ) {
                        ChangeWidgetFont( subMenu, fontDesc );
                    }
                }
            } else
            if ( subw is Gtk.Container subContainer ) {
                ChangeContainerFont( subContainer, fontDesc );
            }
        }
    }
    
    public static void ChangeWidgetFont(Gtk.Widget w, string fontDesc)
    {
        w.ModifyFont( Pango.FontDescription.FromString( fontDesc ) );
    }
