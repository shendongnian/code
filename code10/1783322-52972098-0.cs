    using System;
    using Gtk;
    
    public partial class MainWindow: Gtk.Window
    {
    
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
     Build (); 
      int b = 5;
        if (b == 5) 
        {
        label2.Text="hello";
        }
        else label2.Text="world"; 
    }
    
      protected void OnDeleteEvent (object sender, DeleteEventArgs a)
      {
        Application.Quit ();
        a.RetVal = true; 
       }
    }
