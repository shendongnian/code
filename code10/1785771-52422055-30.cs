    //Not fully implemented, just showing the idea:
    #if NETFULL
    using System.Windows.Controls;
    #elif NETCORE
    using Eto.Forms;
    #endif
    namespace PortabilityLibrary.Shims
    {
	    public class MenuItemShim : Shim<
    #if NETFULL
		MenuItem
    #elif NETCORE
		MenuItem
    #endif
	    >
	    {
		    public MenuItemShim(EventHandler<EventArgs> dlg)
    #if NETFULL
		    : base(new MenuItem(/*not implemented*/))
    #elif NETCORE
			: base(new ButtonMenuItem(dlg))
    #endif
		    { }
	    }
    }
