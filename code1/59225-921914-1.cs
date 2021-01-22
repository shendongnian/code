    public class Loading
    {
        public delegate void EmptyDelegate();
        private frmLoadingForm _frmLoadingForm;
        private readonly Thread _newthread;
        public Loading()
        {
            Console.WriteLine("enteredFrmLoading on thread: " + Thread.CurrentThread.ManagedThreadId);
            _newthread = new Thread(new ThreadStart(Load));
            _newthread.SetApartmentState(ApartmentState.STA);
            _newthread.Start();
        }
        public void Load()
        {
            Console.WriteLine("enteredFrmLoading.Load on thread: " + Thread.CurrentThread.ManagedThreadId);
            _frmLoadingForm = new frmLoadingForm();
            if(_frmLoadingForm.ShowDialog()==DialogResult.OK)
            {
                
            }
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            Console.WriteLine("enteredFrmLoading.Close on thread: " + Thread.CurrentThread.ManagedThreadId);
            if (_frmLoadingForm != null)
            {
                if (_frmLoadingForm.InvokeRequired)
                {
                    _frmLoadingForm.Invoke(new EmptyDelegate(_frmLoadingForm.Close));
                }
                else
                {
                    _frmLoadingForm.Close();
                }
            }
            _newthread.Abort();
        }
    }
    public partial class frmLoadingForm : Form
    {
 
        public frmLoadingForm()
        {
            InitializeComponent();
        }
    }
