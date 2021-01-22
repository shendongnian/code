    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace MimimalSilverlightApp
    {
        public class App : Application
        {
            public App()
            {
                this.Startup += this.Application_Startup;
            }
    
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                var canvas = new Canvas();
    
                var textblock = new TextBlock();
                textblock.FontSize = 24;
                textblock.Text = "Hello!";
                canvas.Children.Add(textblock);
    
                this.RootVisual = canvas;
            }
        }
    }
