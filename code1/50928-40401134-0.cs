    using NLog;
    using System;
    using System.Windows;
    
    namespace MyApp
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private static Logger logger = LogManager.GetCurrentClassLogger();
    
            public App()
            {
                var currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
    
            private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                var ex = (Exception)e.ExceptionObject;
                logger.Error("UnhandledException caught : " + ex.Message);
                logger.Error("UnhandledException StackTrace : " + ex.StackTrace);
                logger.Fatal("Runtime terminating: {0}", e.IsTerminating);
            }        
        }
    
        
    }
