    using System;
    using Gtk;
    
    public partial class MainWindow : Gtk.Window
    {
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            Build();
        }
    
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
            a.RetVal = true;
        }
    }
