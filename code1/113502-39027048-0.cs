    public partial class WaitForm : Form
    {
        private readonly MethodInvoker method;
        public WaitForm(MethodInvoker action)
        {
            InitializeComponent();
            method = action;
        }
        private void WaitForm_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                method.Invoke();
                InvokeAction(this, Dispose);
            }).Start();
        }
        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
