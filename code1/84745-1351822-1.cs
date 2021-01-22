    public class NewCountArgs : EventArgs
    {
        public NewCountArgs(int count)
        {
             Count = count;
        }
        public int Count
        {
           get; protected set;
        }
    }
    public class ADP 
    {
         public event EventHandler<NewCountArgs> NewCountsAvailable;
         private double _interval;
         private double _steps;
         private Thread _backgroundThread;
         public void StartAcquisition(double interval, double steps)
         {
              _interval = interval;
              _steps = steps;
              // other setup work
              _backgroundThread = new Thread(new ThreadStart(StartBackgroundWork));
              _backgroundThread.Start();
         }
         private void StartBackgroundWork()
         {
             // setup async calls on this thread
             m_rdrCountReader.BeginReadMultiSampleUInt32(-1, Callback, _steps);
         }
         private void Callback(IAsyncResult result)
         {
             int counts = 0;
             // read counts from result....
             // raise event for caller
             if (NewCountsAvailable != null)
             {
                 NewCountsAvailable(this, new NewCountArgs(counts));
             }
         }
    }
    public class Form1 : Form
    {
         private ADP _adp1;
         private TextBox txtOutput; // shows updates as they occur
         delegate void SetCountDelegate(int count);
         public Form1()
         {
             InitializeComponent(); // assume txtOutput initialized here
         }
         public void btnStart_Click(object sender, EventArgs e)
         {
              _adp1 = new ADP( .... );
              _adp1.NewCountsAvailable += NewCountsAvailable;
              _adp1.StartAcquisition(....);
              while(!_adp1.IsDone)
              {
                  Thread.Sleep(100);
                  // your NewCountsAvailable callbacks will queue up
                  // and will need to be processed
                  Application.DoEvents();
              }
              // final work here
         }
         // this event handler will be called from a background thread
         private void NewCountsAvailable(object sender, NewCountArgs newCounts)
         {
             // don't update the UI here, let a thread-aware method do it
             SetNewCounts(newCounts.Count);
         }
         private void SetNewCounts(int counts)
         {
             // if the current thread isn't the UI thread
             if (txtOutput.IsInvokeRequired)
             {
                // create a delegate for this method and push it to the UI thread
                SetCountDelegate d = new SetCountDelegate(SetNewCounts);
                this.Invoke(d, new object[] { counts });  
             }
             else
             {
                // update the UI
                txtOutput.Text += String.Format("{0} - Count Value: {1}", DateTime.Now, counts);
             }
         }
    }
