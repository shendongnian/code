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
            var srv = new ServiceController("MYSERVICE");
            AppLog.Log(string.Format("MYSERVICE Status {0}", srv.Status));
        }
        protected override void OnStop()
        {
            mytimer.Stop();
        }
    }
    public static class AppLog
    {
        public static string z = "SrvControl";
        static EventLog Logger = null;
        public static void Log(string message)
        {
            if (Logger == null)
            {
                if (!(EventLog.SourceExists(z)))
                    EventLog.CreateEventSource(z, "Application");
                Logger = new EventLog("Application");
                Logger.Source = z;
            }
            Logger.WriteEntry(message, EventLogEntryType.Information);
        }
    }
   
