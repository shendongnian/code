    public partial class BusyDialog : Window
    {
        public BusyDialog()
        {
            InitializeComponent();
        }
        public static T Execute<T>(DependencyObject parent, Func<T> action)
        {
            Window parentWindow = null;
            if (parent is Window)
            {
                parentWindow = parent as Window;
            }
            else
            {
                parentWindow = Window.GetWindow(parent);
            }
            T val = default(T);
            Exception le = null;
            BusyDialog bd = new BusyDialog();
            bd.Owner = parentWindow;
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    val = action();
                }
                catch (Exception ex)
                {
                    le = ex;
                }
                bd.EndDialog();
            });
            bd.ShowDialog();
            if (le != null)
            {
                Trace.WriteLine(le.ToString());
                throw new Exception("Execute Exception", le);
            }
            return val;
        }
        private void EndDialog()
        {
            Dispatcher.Invoke((Action)delegate() {
                this.DialogResult = true;
            });
        }
    }
