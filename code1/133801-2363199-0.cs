    public partial class Window1 : Window
    {
        private EventHandler handler;
        public Window1()
        {
            InitializeComponent();
 
            handler = delegate
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(4);
                timer.Tick += delegate
                {
                    if (timer != null)
                    {
                        timer.Stop();
                        timer = null;
                        System.Windows.Interop.ComponentDispatcher.ThreadIdle -= handler;
                        MessageBox.Show("You get caught!");
                        System.Windows.Interop.ComponentDispatcher.ThreadIdle += handler;
                    }
 
                };
 
                timer.Start();
 
                //System.Windows.Interop.ComponentDispatcher.ThreadIdle -= handler;
                Dispatcher.CurrentDispatcher.Hooks.OperationPosted += delegate
                {
                    if (timer != null)
                    {
                        timer.Stop();
                        timer = null;
                    }
                };
            };
 
            ComponentDispatcher.ThreadIdle += handler;
        }
    }
