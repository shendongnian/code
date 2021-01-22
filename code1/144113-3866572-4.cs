    using System;
    using Gtk; 
    namespace Visitors.Clases.MessageBox
    {	
        public static class MessageBox 
        {
            public static Gtk.ResponseType Show(Gtk.Window window, Gtk.DialogFlags dialogflags, MessageType msgType,ButtonsType btnType,string Message,String caption)
            {
                MessageDialog md = new MessageDialog (window,dialogflags,msgType,btnType, Message);
                md.Title = caption;
                ResponseType tp = (Gtk.ResponseType)md.Run();		
                md.Destroy(); 
                return tp;
            }
        }
    }
