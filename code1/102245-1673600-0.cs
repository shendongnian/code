    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using System.Threading;
    
    namespace WindowsServiceTest
    {
        public partial class Service1 : ServiceBase
        {
            private System.Timers.Timer timer;
    
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                //instantiate timer
                Thread t = new Thread(new ThreadStart(this.InitTimer)); 
                t.Start();
            }
    
            protected override void OnStop()
            {
                timer.Enabled = false;
            }
    
             private void InitTimer()  
             {     
                 timer = new System.Timers.Timer();  
                 //wire up the timer event 
                 timer.Elapsed += new ElapsedEventHandler(timer_Elapsed); 
                 //set timer interval   
                 //var timeInSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["TimerIntervalInSeconds"]); 
                 double timeInSeconds = 3.0;
                 timer.Interval = (timeInSeconds * 1000); 
                 // timer.Interval is in milliseconds, so times above by 1000 
                 timer.Enabled = true;  
             }
    
            protected void timer_Elapsed(object sender, ElapsedEventArgs e) 
            {
                int timer_fired = 0;
            }
        }
    }
