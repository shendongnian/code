    public class Loading
    {
        public delegate void EmptyDelegate();
        private frmLoadingForm fl;
        private readonly Thread newthread;
        public Loading()
        {
            BackgroundWorker bw = new BackgroundWorker();
            Console.WriteLine("enteredFrmLoading on thread: " + Thread.CurrentThread.ManagedThreadId);
            newthread = new Thread(new ThreadStart(Load));
            newthread.SetApartmentState(ApartmentState.STA);
            newthread.Start();
        }
        public void Load()
        {
            Console.WriteLine("enteredFrmLoading.Load on thread: " + Thread.CurrentThread.ManagedThreadId);
            fl = new frmLoadingForm();
            if(fl.ShowDialog()==DialogResult.OK)
            {
                
            }
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            Console.WriteLine("enteredFrmLoading.Close on thread: " + Thread.CurrentThread.ManagedThreadId);
            if (fl != null)
            {
                if (fl.InvokeRequired)
                {
                    fl.Invoke(new EmptyDelegate(fl.Close));
                }
                else
                {
                    fl.Close();
                }
            }
            newthread.Abort();
        }
    }
    public partial class frmLoadingForm : Form
    {
 
        public frmLoadingForm()
        {
            InitializeComponent();
        }
    }
