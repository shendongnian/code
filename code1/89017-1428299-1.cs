    using System.Windows.Forms;
    using System.Threading;
    class UserInterfaceThread()
    {
        static Form window;
        public UserInterfaceThread()
        {
            var thread = new Thread(() => {
                window = new Form();
                var handle = window.Handle;
                Application.Run();
                });
                thread.Start();
            }
        }
        public void Run(Action action)
        {
            window.Invoke(action);
        }
    }
