    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			var bw = new BackgroundWorker();
    			bw.DoWork += Bw_DoWork;
    			bw.WorkerReportsProgress = true;
    			bw.ProgressChanged += Bw_ProgressChanged;
    			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
    			bw.RunWorkerAsync();
    		}
    
    		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    		{
    			MessageBox.Show("attach");
    			//dt = dl.loadTransfer(status);
    			//dgvDashboard.AutoGenerateColumns = false;
    			//dgvDashboard.DataSource = dt;
    		}
    
    		private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    		{
    			if (e.ProgressPercentage == 0)
    			{
    				label1.Text = "Request Data";
    			}
    			else if (e.ProgressPercentage == 3)
    			{
    				label1.Text = "Fetching Data";
    			}
    			else if (e.ProgressPercentage == 6)
    			{
    				label1.Text = "Loading Data";
    			}
    			else if (e.ProgressPercentage == 9)
    			{
    				label1.Text = "Done";
    			}
    		}
    
    		private void Bw_DoWork(object sender, DoWorkEventArgs e)
    		{
    			BackgroundWorker worker = sender as BackgroundWorker;
    			int notiCount = 0;
    			do
    			{
    
    				Thread.Sleep(1000);
    
    				notiCount++;
    
    				worker.ReportProgress(notiCount);
    			}
    			while (notiCount <= 10);
    		}
    	}
    }
