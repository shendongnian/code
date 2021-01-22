    using System;
    using QTObjectModelLib;
    
    namespace QtpDemo
    {
        class QtpDriver
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application app = new Application();
                app.Launch();
                app.Visible = true;
            }
        }
    }
