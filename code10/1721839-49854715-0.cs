    using System;
    using Gtk;
    
    namespace Application
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Gtk.Application.Init();
                MainWindow win = new MainWindow();
                win.Show();
                Gtk.Application.Run();
            }
        }
    }
