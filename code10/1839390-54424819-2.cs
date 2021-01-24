    namespace SO_Wpf
    {
        using System;
        using System.Diagnostics;
        using System.IO;
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
                if (e.Exception.GetType() == typeof(FileNotFoundException))
                {
                    if (!CheckLibrarys())
                    {
                        Current.Shutdown();
                    }
                }
            }
    
            private void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                if (e.ExceptionObject.GetType() == typeof(FileNotFoundException))
                {
                    if (!CheckLibrarys())
                    {
                        Current.Shutdown();
                    }
                }
            }
    
            private static bool CheckLibrarys()
            {
                if (!IsResourceExist("MyLib.dll"))
                {
                    return false;
                }
    
                //Other resources checking same way
                return true;
            }
    
            private static bool IsResourceExist(string fileName)
            {
                var process = Process.GetCurrentProcess();
                var path = process.MainModule.FileName.Replace("\\" + process.ProcessName + ".exe", "");
                try
                {
                    if (!File.Exists(Path.Combine(path, fileName)))
                    {
                        MessageBox.Show("Unable to load " + fileName + " library\nReinstall application and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
