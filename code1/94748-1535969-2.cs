	using System;   
	using System.Threading;   
	using System.Threading.Tasks;   
	using System.Windows.Forms;   
	  
	class SimpleProgressBar : Form   
	{   
		[STAThread]   
		static void Main(string[] args)   
		{   
			Application.EnableVisualStyles();   
			Application.Run(new SimpleProgressBar());   
		}   
	  
		protected override void OnLoad(EventArgs e)   
		{   
			base.OnLoad(e);   
	  
			int iterations = 100;   
	  
			ProgressBar pb = new ProgressBar();   
			pb.Maximum = iterations;   
			pb.Dock = DockStyle.Fill;   
			Controls.Add(pb);   
	  
			Task.ContinueWith(delegate   
			{   
				Parallel.For(0, iterations, i =>  
				{   
					Thread.SpinWait(50000000); // do work here   
					BeginInvoke((Action)delegate { pb.Value++; });   
				});   
			});   
		}   
	}  
