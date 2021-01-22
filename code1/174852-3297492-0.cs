    using System;
    using System.Threading;
    using System.ServiceProcess;
    
    namespace Code
    {
    	public partial class Service : ServiceBase
    	{
    		Timer timer;
    		AutoResetEvent autoEvent;
    		bool stopped = true;
    
    		public Service()
    		{
    			InitializeComponent();
    		}
    
    		protected override void OnStart(string[] args)
    		{
    			stopped = false;
    			TimerCallback tcb = new TimerCallback(OnElapsedTime);
    			timer = new Timer(tcb, null, 10000, 600000);
    		}
    
    		protected override void OnStop()
    		{
    			stopped = true;
    			timer.Dispose();
    		}
    
    		private void OnElapsedTime(Object stateInfo)
    		{
    			if (stopped)
    				return;
    
    			// Run system code here
    		}
    	}
    }
