    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    namespace SrvControl
    {
    public partial class Service1 : ServiceBase
    {
        Timer mytimer;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (mytimer == null)
                mytimer = new Timer(5 * 1000.0);
            mytimer.Elapsed += new ElapsedEventHandler(mytimer_Elapsed);
            mytimer.Start();
        }
        void mytimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Do Anything, e.g. write to eventlog
        }
        protected override void OnStop()
        {
            mytimer.Stop();
        }
    }
    }
