    namespace SO_Wpf
    {
        using System;
        using System.Windows;
        using System.Windows.Threading;
    
        public partial class App : Application
        {
            public App()
            {
                Current.DispatcherUnhandledException += this.AppDispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += this.AppDomainUnhandledException;
            }
    
            private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
            {
                MessageBox.Show(e.ToString());
            }
    
            private void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
