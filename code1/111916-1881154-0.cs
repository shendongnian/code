        private BackgroundWorker bgWorker;
        public Form1()
        {
            InitializeComponent();
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.RunWorkerAsync();
        }
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           this.label2.Text = "Done";
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           MyStatus myProgressStatus = (MyStatus)e.UserState;
           this.label2.Text = string.Format("segments write : {0}" + Environment.Newline + "Segments Remain: {1}", myProgressStatus.iWritten, myProgressStatus.iRemaining);
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            long FSS = din.TotalFreeSpace;
                long segments = FSS / 10000;
                long last_seg = FSS % 10000;
                BinaryWriter br = new BinaryWriter(fs);
                for (long i = 0; i &lt; segments; i++)
                {
                    br.Write(new byte[10000]);
bgWorker.ReportProgress(i.ToString(), new MyStatus(i, ((segments-i) + 1)));
                    
                }
                br.Write(new byte[last_seg]);
                br.Close();
        }
public class MyStatus{
   public int iWritten;
   public int iRemaining;
   public MyStatus(int iWrit, int iRem){
     this.iWritten = iWrit;
     this.iRemaining = iRem;
   }
}
}
