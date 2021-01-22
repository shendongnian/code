    public partial class Form1 : Form
    {
        private TestNetStat netStat = new TestNetStat();
        public Form1()
        {
           InitializeComponent();
           using (BackgroundWorker bgWorker = new BackgroundWorker())
           {
               bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
               bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
               bgWorker.RunWorkerAsync();
           }
        }
    
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           System.Diagnostics.Debug.WriteLine("BGWORKER ENDED!");
        }
    
        private void  bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           netStat.Run();
        } 
        void btnPost_Click(object sender, EventArgs e)
        {
           netStat.PostCtrlC();
           System.Diagnostics.Debug.WriteLine(string.Format("[{0}] - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), this.netStat.OutputData.Replace(Environment.NewLine, "")));
        }
    }
    
    public class TestNetStat
    {
        private StringBuilder sbRedirectedOutput = new StringBuilder();
        //
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        public string OutputData
        {
           get { return this.sbRedirectedOutput.ToString(); }
        }
        public void PostCtrlC()
        {
           IntPtr ptr = FindWindow(null, @"C:\Windows\System32\netstat.exe");
           if (ptr != null)
           {
              SetForegroundWindow(ptr);
              Thread.Sleep(1000);
              WindowsInput.InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.CANCEL);
              // SendKeys.Send("^{BREAK}");
              Thread.Sleep(1000);
            }
        }
        public void Run()
        {
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo();
            ps.FileName = "netstat";
            ps.ErrorDialog = false;
            ps.Arguments = "-e 5";
            ps.CreateNoWindow = true;
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
               proc.StartInfo = ps;
               proc.EnableRaisingEvents = true;
               proc.Exited += new EventHandler(proc_Exited);
               proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_OutputDataReceived);
               proc.Start();
               proc.BeginOutputReadLine();
               proc.WaitForExit();
            }
         }
    
         void proc_Exited(object sender, EventArgs e)
         {
            System.Diagnostics.Debug.WriteLine("proc_Exited: Process Ended");
         }
    
         void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
         {
             if (e.Data != null)
             {
                this.sbRedirectedOutput.Append(e.Data + Environment.NewLine);
                System.Diagnostics.Debug.WriteLine("proc_OutputDataReceived: Data: " + e.Data);
             }
         }
    }
