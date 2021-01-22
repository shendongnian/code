    public partial class MainApplicationWindow : Form
    {
        private LongProcessClass _longProcess;
  
        public MainApplicationWindow
        {
            this.InitializeComponent();
            this._longProcess = new LongProcessClass();
            // bind UI updating method to long process class event
            this._longProcess.ReportCompletition += this.DisplayCompletitionInfo;
        }
 
        private void DisplayCompletitionInfo(double completition)
        {  
            // check if control you want to display info in needs to be invoked
            // - request is coming from different thread
            if (control.InvokeRequired)
            {
                Action<double> updateMethod = this.DisplayCompletitionInfo;
                control.Invoke(updateMethod, new object[] { completition });
            }
            // here you put code to do actual UI updating, 
            // eg. displaying status message
            else
            {
                int progress = (int) completition * 10;
                control.Text = "Please wait. Long process progress: " 
                    + progress.ToString() + "%";
            }
        }
 
