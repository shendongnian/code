    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string PrintMessage(string message);
    }
    public class Service : IService
    {
        public string PrintMessage(string message)
        {
            // Invoke the delegate here.
            try {
                if (TextUpdater != null)
                {
                    TextUpdater(this, new UpdateTextEventArgs("Hello"));
                }
            } catch {
            }
        }
        public UpdateTextDelegate TextUpdater { get; set; }
    }
    public delegate void UpdateTextDelegate(object sender, UpdateTextEventArgs e);
    public class UpdateTextEventArgs
    {
        public string Text { get; set; }
        public UpdateTextEventArgs(string text)
        {
            Text = text;
        }
    }
    public class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Create your WCF service here...
            // Set the delegate for the WCF service to call when
            // PrintMessage() is called.
            service.TextUpdater = ShowMessageBox;
        }
        // The ShowMessageBox() method has to match the signature of
        // the UpdateTextDelegate delegate.
        public void ShowMessageBox(object sender, UpdateTextEventArgs e)
        {
            // Use Invoke() to make sure the UI interaction happens
            // on the UI thread...just in case this delegate is
            // invoked on another thread.
            Invoke((MethodInvoker) delegate {
                MessageBox.Show(e.Text);
            } );
        }
    }
