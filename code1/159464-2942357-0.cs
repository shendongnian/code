    public partial class App
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("Exiting");
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var testThread = new Thread(
                () =>
                {
                    Thread.Sleep(2000);
                    Application.Current.Dispatcher.BeginInvokeShutdown(System.Windows.Threading.DispatcherPriority.Send);
                    //Application.Current.Dispatcher.BeginInvoke(new Action(() => Application.Current.Shutdown()));
                });
            testThread.Start();
        }
    }
    public partial class Window1
    {
        public Window1()
        {
            this.InitializeComponent();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("One");
            }));
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Two");
            }));
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Three");
            }));
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Four");
            }));
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Closed");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("Closing");
        }
    }
