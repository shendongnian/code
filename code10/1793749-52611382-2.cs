    using System;
    using System.ComponentModel;    
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace StackOverflow02
    {
    	public partial class DVMLoopRunner : Form
    	{
    		public DVMLoopRunner()
    		{
    			InitializeComponent();
    			DVMReadingAvailable += Form1_DVMReadingAvailable;
    			ContinueOrCancel += Form1_ContinueOrCancel;
    		}
    		// See if User has turned off the Run button then cancel worker
    		private void Form1_ContinueOrCancel(Object sender, CancelEventArgs e)
    		{
    			e.Cancel = !checkBoxRunMeterLoop.Checked;
        	}
    		// The DVM, after being triggered + some delay, has come up with a new reading.
    		private void Form1_DVMReadingAvailable(Object sender, DVMReadingAvailableEventArgs e)
    		{
    			// To update GUI from worker thread requires Invoke to prevent Cross-Thread Exception
    			Invoke((MethodInvoker)delegate
    			{
    				textBox1.Text = e.Reading.ToString("F4");
    			});
    		}
    		// Make our events so that we can be notified of things that occur
    		public event CancelEventHandler ContinueOrCancel;					
    		public event DVMReadingAvailableEventHandler DVMReadingAvailable;
    		// This is how we will provide info to the GUI about the new reading
    		public delegate void DVMReadingAvailableEventHandler(Object sender, DVMReadingAvailableEventArgs e);
    		public class DVMReadingAvailableEventArgs : EventArgs
    		{
    			public readonly double Reading;
    			public DVMReadingAvailableEventArgs(double reading)
    			{
    				Reading = reading;
    			}
    		}
    		// When the User checks the box, Run the worker loop
    		private void checkBoxRunMeterLoop_CheckedChanged(Object sender, EventArgs e)
    		{
    			if(checkBoxRunMeterLoop.Checked)
    			{
    				Task.Run(() => ReadDVMWorker());
    			}
    		}
    		// Worker Loop
    		private void ReadDVMWorker()
    		{
    			while(true)
    			{
    				CancelEventArgs e = new CancelEventArgs();
    				ContinueOrCancel?.Invoke(this, e);
    				if (e.Cancel) return;               // If User has turned off the Run button then stop worker
    				ReadDVM();						    // This worker thread will block on this. So trigger, wait, etc.
    			}
    		}
    		// DVM Takes some period of time after trigger
    		void ReadDVM()
    		{
    			Thread.Sleep(1000);
    			double newSimulatedReading = 4.5 + Random.NextDouble();
    			DVMReadingAvailable?.Invoke(this, new DVMReadingAvailableEventArgs(newSimulatedReading));
    		}
    		Random Random = new Random();	// Generate random readings for simulation
    	}
    }
