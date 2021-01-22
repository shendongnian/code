    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    
    namespace DelayedStartDemo
    {
        public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                Thread.Sleep(5000);
    
                base.OnStartup(e);
    
                Debug.Assert(MainWindow == null);
            }
    
            protected override void OnActivated(System.EventArgs e)
            {
                Debug.Assert(MainWindow != null && 
                             MainWindow.Visibility == Visibility.Visible && 
                             MainWindow.ShowInTaskbar);
                
                base.OnActivated(e);
            }
        }
    }
