	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;
	namespace iGEENIESU_MemoryOptimization
	{
	    public partial class iGEENIEMemoryOptimize : Form
	    {
	        public iGEENIEMemoryOptimize()
	        {
	            InitializeComponent();
	        }
	
	
	        [StructLayout(LayoutKind.Sequential)]
	        internal class MEMORYSTATUS
	        {
	            internal int length;
	            internal int memoryLoad;
	            internal uint totalPhys;
	            internal uint availPhys;
	            internal uint totalPageFile;
	            internal uint availPageFile;
	            internal uint totalVirtual;
	            internal uint availVirtual;
	        }
	
	        [DllImport("kernel32.dll", SetLastError = true)]
	        internal static extern bool GlobalMemoryStatus(MEMORYSTATUS buffer);
	
	        internal bool bLoop;
	
	        private void iGEENIEMemoryOptimize_Load(object sender, EventArgs e)
	        {
	            bLoop = true;
	            backgroundWorker1.WorkerReportsProgress = true;
	            backgroundWorker1.WorkerSupportsCancellation = false;
	            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
	            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
	            backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
	            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
	           
	            backgroundWorker1.RunWorkerAsync();
	            backgroundWorker2.RunWorkerAsync();
	           
	        }
	
	        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	        {
	           
	           // MessageBox.Show("Ting Choo Chiaw has optimize your memory, have fun");
	            Application.Exit();
	        }
	
	        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	        {
	            this.pbmemoryoptimiz.Value = e.ProgressPercentage;
	        }
	        void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
	        {
	            int iCount = 0;
	            while (iCount<10)
	            {
	               
	                iCount++;
	                this.backgroundWorker1.ReportProgress(iCount, null);
	                System.Threading.Thread.Sleep(1000);
	               
	            }
	            bLoop = false;
	        }
	        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	        {
	            MEMORYSTATUS status = new MEMORYSTATUS();
	
	            GlobalMemoryStatus(status);
	
	            int mem = (int)status.totalPhys;
	
	            byte[] src = null;
	            bool bContinue = true;
	            do
	            {
	                try
	                {
	                    src = new byte[mem];
	                    int len = src.Length;
	
	                    while (true && bLoop)
	                    {
	                        len--;
	                        if (len <= 0)
	                            return;
	
	                        src[len] = 0;
	                    }
	
	                    bContinue = false;
	                }
	                catch (OutOfMemoryException)
	                {
	                    mem = (int)((double)mem * 0.99);
	                }
	
	            } while (bContinue);
	            backgroundWorker1.ReportProgress(10);
	            if (backgroundWorker2 != null)
	                if (backgroundWorker2.IsBusy)
	                    backgroundWorker2.CancelAsync();
	            src = null; // free resources instancely
	
	            GC.Collect();
	            GC.GetTotalMemory(false);
	            GC.Collect();
	        }
	    }
	}
